using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using NewSale.Common;
using NewSale.Common.Exceptions;
using NewSale.Dto.Common;
using NewSale.Dto.Request;

namespace NewSale.Domain
{
   /// <summary>
   /// 订单信息
   /// </summary>
    public class Order
    {
        private List<OrderLine> _lines;

        public Order()
        {
            _lines = new List<OrderLine>();
        }

        /// <summary>
        /// 创建订单（简单工厂）
        /// </summary>
        /// <param name="orderNo"></param>
        /// <param name="address"></param>
        /// <param name="skus"></param>
        /// <returns></returns>
        public static Order Create(string orderNo, Address address, SaleSkuInfo[] skus)
        {
            Order order = new Order();
            order.OrderNo = orderNo;
            order.Address = address;
            order.Status = OrderStatus.PendingPayment;
      
            foreach(var sku in skus)
            {
                order.AddLine(sku.Id,sku.Qty);
            }
            
            order.CalculateFee();
            return order;
        }

        /// <summary>
        /// Id
        /// </summary>
        public int Id{get; private set;}

        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNo{get; private set;}

        /// <summary>
        /// 订单状态
        /// </summary>
        public OrderStatus Status{get; private set;}

        /// <summary>
        /// 收货地址
        /// </summary>
        public Address Address{get; private set;}

        /// <summary>
        /// 订单明细
        /// </summary>
        public List<OrderLine> Lines
        {
          get{return this._lines;}
          private set { this._lines = value; }
        }
        
        /// <summary>
        /// 运费
        /// </summary>
        public decimal ShippingFee { get; private set; }
    
        /// <summary>
        /// 折扣金额
        /// </summary>
        public decimal Discount{ get; private set; }
        
        /// <summary>
        /// 商品总价值
        /// </summary>
        public decimal GoodsTotal { get; private set; }

        /// <summary>
        /// 应付金额
        /// </summary>
        public decimal DueAmount { get; private set; }

        /// <summary>
        /// 实付金额
        /// </summary>
        public decimal ActAmount { get; private set; }

       /// <summary>
        /// 添加明细
        /// </summary>
        /// <param name="skuId"></param>
        /// <param name="qty"></param>
        public void AddLine(int skuId, int qty)
        {
            var product = ServiceProxy.ProductService.GetProduct(new GetProductRequest{SkuId = skuId});
            if(product == null)
            {
                throw new SkuNotFindException(skuId);
            }
        
            OrderLine line = new OrderLine(skuId, product.SkuName, product.Spec, qty, product.Cost, product.Price);
            this._lines.Add(line);
        }

        /// <summary>
        /// 订单费用计算
        /// </summary>
        public void CalculateFee()
        {
            this.CalculateGoodsTotal();
            this.CalculateShippingFee();
            this.CalculateDiscount();
            this.CalculateDueAmount();
        }

       /// <summary>
       /// 订单支付
       /// </summary>
       /// <param name="money"></param>
       public void Pay(decimal money)
       {
           if (money <= 0)
           {
               throw new ArgumentException("支付金额必须大于0");
           }
           this.ActAmount += money;

           if (this.ActAmount >= this.DueAmount)
           {
               if (this.Status == OrderStatus.PendingPayment)
               {
                   this.Status = OrderStatus.PendingShipment;
               }
           }
       }

       /// <summary>
        /// 计算运费
        /// </summary>
        private decimal CalculateShippingFee()
        {
           //够买商品总价值小于100则收取8元运费
            this.ShippingFee = this.CalculateGoodsTotal() > 100 ? 0 : 8m;
           return this.ShippingFee;
        }

        /// <summary>
        /// 计算折扣
        /// </summary>
        private decimal  CalculateDiscount()
        {
           this.Discount = decimal.Zero; //todo zhangsan 暂未实现
           return this.Discount;
        }

        /// <summary>
        /// 计算商品总价值
        /// </summary>
        private decimal CalculateGoodsTotal()
        {
           this.GoodsTotal = this.Lines.Sum(line => line.CalculateTotal());
           return this.GoodsTotal;
        }

        /// <summary>
        /// 计算应付金额
        /// </summary>
        /// <returns></returns>
        private decimal CalculateDueAmount()
        {
            this.DueAmount = this.CalculateGoodsTotal() + CalculateShippingFee() - CalculateDiscount();
            return this.DueAmount;
        }
    }
}
