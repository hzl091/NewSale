using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewSale.Domain
{
    //订单状态
    public enum OrderStatus
    {
        /// <summary>
        /// 待支付
        /// </summary>
        PendingPayment = 0,

        /// <summary>
        /// 待发货
        /// </summary>
        PendingShipment = 10,

        /// <summary>
        /// 待收货
        /// </summary>
        PendingReceive = 20,

        /// <summary>
        /// 已收货
        /// </summary>
        Received = 30,

        /// <summary>
        /// 已取消
        /// </summary>
        Canceled = 40
    }
}
