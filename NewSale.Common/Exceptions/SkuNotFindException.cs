using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewSale.Common.Exceptions
{
    public class SkuNotFindException
        : NewSaleException
    {
        public SkuNotFindException(int skuId)
            : base(ExCodes.SkuNotFind, string.Format("产品信息未找到,skuId[{0}]", skuId))
        {
        }
    }
}
