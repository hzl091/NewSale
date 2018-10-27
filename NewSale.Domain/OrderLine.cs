using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewSale.Domain
{
    /// <summary>
    /// 订单明细
    /// </summary>
    public class OrderLine
    {
        public OrderLine()
        { }

        public OrderLine(int skuId, string skuName, string spec, int qty, decimal cost, decimal price)
            : this()
        {
            this.SkuId = skuId;
            this.SkuName = skuName;
            this.Spec = spec;
            this.Qty = qty;
            this.Cost = cost;
            this.Price = price;
        }

        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 商品Id
        /// </summary>
        public int SkuId { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string SkuName { get; set; }

        /// <summary>
        /// 商品规格
        /// </summary>
        public string Spec { get; set; }

        /// <summary>
        /// 购买数量
        /// </summary>
        public int Qty { get; set; }

        /// <summary>
        /// 成本价
        /// </summary>
        public decimal Cost { get; set; }

        /// <summary>
        /// 售价
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 小计
        /// </summary>
        public decimal Total { get; set; }

        /// <summary>
        /// 小计金额计算
        /// </summary>
        /// <returns></returns>
        public decimal CalculateTotal()
        {
            this.Total = Qty * Price;
            return this.Total;
        }
    }
}
