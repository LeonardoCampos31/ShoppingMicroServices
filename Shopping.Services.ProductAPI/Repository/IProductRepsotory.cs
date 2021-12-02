using Shopping.Services.ProductAPI.Models.Dto;

namespace Shopping.Services.ProductAPI.Repository
{
    public interface IProductRepsotory
    {
        Task<IEnumerable<ProductDto>> GetProducts();
        Task<ProductDto> GetProductById(int productId);
        Task<ProductDto> CreateUpateProduct(ProductDto productDto);
        Task<bool> DeleteProduct(int productId);
    }
}
