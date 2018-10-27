using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewSale.Dto.Request;
using NewSale.Dto.Response;

namespace NewSale.IService
{
    /// <summary>
    /// 产品服务代理接口
    /// </summary>
    public interface IProductServiceProxy
    {
        /// <summary>
        /// 获取产品信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetProductResponse GetProduct(GetProductRequest request);
    }
}
