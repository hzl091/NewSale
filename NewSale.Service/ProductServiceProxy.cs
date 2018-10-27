using NewSale.Dto.Request;
using NewSale.Dto.Response;
using NewSale.IService;

namespace NewSale.Service
{
    /// <summary>
    /// 产品服务代理接口
    /// </summary>
    public class ProductServiceProxy : IProductServiceProxy
    {
        public GetProductResponse GetProduct(GetProductRequest request)
        {
            //todo zhangsan 这里先硬编码数据进行模拟调用，后期需要调用产品系统Api接口获取数据
            if (request.SkuId == 1138)
            {
                return new GetProductResponse()
                {
                    SkuId = 1138,
                    SkuName = "苹果8",
                    Spec = "128G 金色",
                    Cost = 5000m,
                    Price = 6500m
                };
            }

            if (request.SkuId ==1139)
            {
                return new GetProductResponse()
                {
                    SkuId = 1139,
                    SkuName = "小米充电宝",
                    Spec = "10000MA 白色",
                    Cost = 60m,
                    Price = 100m
                };
            }

            if (request.SkuId == 1140)
            {
                return new GetProductResponse()
                {
                    SkuId = 1140,
                    SkuName = "怡宝瓶装矿泉水",
                    Spec = "200ML",
                    Cost = 1.5m,
                    Price = 2m
                };
            }

            return null;
        }
    }
}
