using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Shopping.Services.ProductAPI;
using Shopping.Services.ProductAPI.DbContexts;
using Shopping.Services.ProductAPI.Models.Dto;
using Shopping.Services.ProductAPI.Repository;
using Xunit;

namespace ShoppingUnitTest
{        
    public class ProductTest
    {
        private IProductRepsotory _productRepsotory;
        private IEnumerable<ProductDto>? products;

        public ProductTest()
        {
            var services = new ServiceCollection();
            services.AddTransient<IProductRepsotory, ProductRepsotory>();

            services.AddSingleton(MappingConfig.RegisterMaps().CreateMapper());
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer("Server=LAPTOP-2VRB7RJK\\SQLEXPRESS;Database=Shopping;Trusted_Connection=True;MultipleActiveResultSets=True");
            });

            var serviceProvider = services.BuildServiceProvider();

            _productRepsotory = serviceProvider.GetService<IProductRepsotory>();
        }

        [Fact]
        public async Task Get()
        {
            products = await _productRepsotory.GetProducts();
        }

        [Fact]
        public async Task GetId()
        {
            var product = _productRepsotory.GetProductById(1);
        }

        [Fact]
        public async Task CreateProduct()
        {
            var product = _productRepsotory.CreateUpateProduct(new ProductDto()
            {
                CategoryName = "1",
                Description = "1",
                ImageUrl = "1",
                Name = "1",
                Price = 1
            });
        }

        [Fact]
        public async Task Delete()
        {
            await _productRepsotory.DeleteProduct(6);
        }
    }
}