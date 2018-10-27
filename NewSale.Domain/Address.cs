using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewSale.Domain
{
    /// <summary>
    /// 地址信息
    /// </summary>
    public class Address
    {
        /// <summary>
        /// 名字
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string FullAddress { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string Tel { get; set; }
    }
}
