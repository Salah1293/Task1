using AutoMapper;
using ProductsAPI.Dtos;
using ProductsAPI.Models;

namespace ProductsAPI.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDetailsDto>();
            CreateMap<ProductDto, Product>();

            CreateMap<Category, CategoryDetailsDto>();
            CreateMap<CategoryDto, Category>();

        }
    }
}
