using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewSale.Dto.Common;

namespace NewSale.Domain.Test
{
    [TestClass]
    public class OrderTest
    {
        /// <summary>
        /// 订单创建逻辑测试
        /// </summary>
        [TestMethod]
        public void CreateOrderTest()
        {
            Address address = new Address();
            address.FullName = "张三";
            address.FullAddress = "广东省深圳市福田区xxx街道888号";
            address.Tel = "13800138000";

            List<SaleSkuInfo> saleSkuInfos = new List<SaleSkuInfo>();
            saleSkuInfos.Add(new SaleSkuInfo(1138,2));
            saleSkuInfos.Add(new SaleSkuInfo(1139, 3));

            //商品总金额大于100分支
            Order order = Order.Create("181027887609", address, saleSkuInfos.ToArray());
            Assert.AreEqual(OrderStatus.PendingPayment, order.Status);
            Assert.AreEqual(2, order.Lines.Count);
            Assert.AreEqual(13300, order.DueAmount);

            //商品总金额小于100分支
            Order order1 = Order.Create("181027887610", address, new SaleSkuInfo[]{ new SaleSkuInfo(1140, 3)});
            Assert.AreEqual(OrderStatus.PendingPayment, order1.Status);
            Assert.AreEqual(1, order1.Lines.Count);
            Assert.AreEqual(8m, order1.ShippingFee);
            Assert.AreEqual(14, order1.DueAmount);
        }

        /// <summary>
        /// 订单支付逻辑测试
        /// </summary>
        [TestMethod]
        public void PayOrderTest()
        {
            Address address = new Address();
            address.FullName = "张三";
            address.FullAddress = "广东省深圳市福田区xxx街道888号";
            address.Tel = "13800138000";

            List<SaleSkuInfo> saleSkuInfos = new List<SaleSkuInfo>();
            saleSkuInfos.Add(new SaleSkuInfo(1138, 2));
            saleSkuInfos.Add(new SaleSkuInfo(1139, 3));

            //商品总金额大于100分支
            Order order = Order.Create("181027887609", address, saleSkuInfos.ToArray());
            Assert.AreEqual(OrderStatus.PendingPayment, order.Status);
            Assert.AreEqual(2, order.Lines.Count);
            Assert.AreEqual(13300, order.DueAmount);

            //部分支付分支
            order.Pay(5000);
            Assert.AreEqual(5000m, order.ActAmount);
            Assert.AreEqual(OrderStatus.PendingPayment, order.Status);

            //部分支付分支
            order.Pay(1000);
            Assert.AreEqual(6000m, order.ActAmount);
            Assert.AreEqual(OrderStatus.PendingPayment, order.Status);

            //全部支付分支
            order.Pay(7300);
            Assert.AreEqual(13300m, order.ActAmount);
            Assert.AreEqual(OrderStatus.PendingShipment, order.Status);
        }
    }
}
