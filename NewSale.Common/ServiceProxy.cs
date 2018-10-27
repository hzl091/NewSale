using NewSale.IService;
using NewSale.Service;

namespace NewSale.Common
{
    /// <summary>
    /// 服务代理
    /// </summary>
    public class ServiceProxy
    {
       public static IProductServiceProxy ProductService
       {
           get
           {
               return new ProductServiceProxy();
           }
           
       }

       public static IShipmentServiceProxy ShipmentServiceProxy
       {
           get
           {
             return new ShipmentServiceProxy();  
           }
       }
    }
}
