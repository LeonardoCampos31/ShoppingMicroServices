using Shopping.Web.Models;
using Shopping.Web.Models.Product;
using Shopping.Web.Services.Interfaces;

namespace Shopping.Web.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IHttpClientFactory _clientFactory;

        public ProductService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<T> CreateProductAsync<T>(ProductDto productDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = productDto,
                Url = SD.ProductAPIBase + "/api/Products",
                AccessToken = ""
            });
        }

        public async Task<T> DeleteProductAsync<T>(int productId)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.ProductAPIBase + "/api/Products/" + productId,
                AccessToken = ""
            });
        }

        public async Task<T> GetProductByIdAsync<T>(int productId)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ProductAPIBase + "/api/Products/" + productId,
                AccessToken = ""
            });
        }

        public async Task<T> GetProductsAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ProductAPIBase + "/api/Products",
                AccessToken = ""
            });
        }

        public async Task<T> UpateProductAsync<T>(ProductDto productDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = productDto,
                Url = SD.ProductAPIBase + "/api/Products",
                AccessToken = ""
            });
        }
    }
}
