using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewSale.Dto.Response
{
    public class GetProductResponse : ResponseBase
    {
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
        /// 成本价
        /// </summary>
        public decimal Cost { get; set; }

        /// <summary>
        /// 实际购买价
        /// </summary>
        public decimal Price { get; set; }
    }
}
