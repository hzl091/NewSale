using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewSale.Dto.Common
{
    public class SaleSkuInfo
    {
        public SaleSkuInfo(int id,int qty)
        {
            this.Id = id;
            this.Qty = qty;
        }

        /// <summary>
        /// 商品Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 购买数量
        /// </summary>
        public int Qty { get; set; }
    }
}
