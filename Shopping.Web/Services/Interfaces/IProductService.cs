using Shopping.Web.Models.Product;

namespace Shopping.Web.Services.Interfaces
{
    public interface IProductService : IBaseService
    {
        Task<T> GetProductsAsync<T>();
        Task<T> GetProductByIdAsync<T>(int productId);
        Task<T> CreateProductAsync<T>(ProductDto productDto);
        Task<T> UpateProductAsync<T>(ProductDto productDto);
        Task<T> DeleteProductAsync<T>(int productId);
    }
}
