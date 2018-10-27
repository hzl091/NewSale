using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewSale.Dto.Request
{
    public class GetProductRequest : RequestBase
    {
        public int SkuId { get; set; }
    }
}
