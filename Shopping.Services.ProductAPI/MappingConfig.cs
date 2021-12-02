using AutoMapper;
using Shopping.Services.ProductAPI.Models;
using Shopping.Services.ProductAPI.Models.Dto;

namespace Shopping.Services.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(cfg => {
                cfg.CreateMap<ProductDto, Product>();
                cfg.CreateMap<Product, ProductDto>();
            });

            return mappingConfig;
        }
    }
}
