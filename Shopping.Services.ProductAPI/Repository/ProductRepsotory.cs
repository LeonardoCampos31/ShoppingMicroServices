using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopping.Services.ProductAPI.DbContexts;
using Shopping.Services.ProductAPI.Models;
using Shopping.Services.ProductAPI.Models.Dto;

namespace Shopping.Services.ProductAPI.Repository
{
    public class ProductRepsotory : IProductRepsotory
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public ProductRepsotory(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateUpateProduct(ProductDto productDto)
        {
            Product product = _mapper.Map<Product>(productDto);

            if (productDto.ProductId > 0)
            {
                _db.Update(product);
            }
            else
            {
                _db.Add(product);
            }

            await _db.SaveChangesAsync();

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                Product product = await _db.Products.FirstOrDefaultAsync(x => x.ProductId == productId);

                if (product != null)
                {
                    _db.Products.Remove(product);
                    await _db.SaveChangesAsync();
                }
                else
                {
                    return false;
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            Product product = await _db.Products.FirstOrDefaultAsync(x => x.ProductId == productId);

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            List<Product> products = await _db.Products.ToListAsync();

            return _mapper.Map<List<ProductDto>>(products);
        }

        public async Task<ProductDto> GetProductByName(string name)
        {
            Product product = await _db.Products.FirstOrDefaultAsync(x => x.Name == name);

            return _mapper.Map<ProductDto>(product);
        }
    }
}
