using AutoMapper;
using api_catalogo.models;
using api_catalogo.Dtos;

namespace api_catalogo.config
{
  public class AutoMapperProfile : Profile
  {

    public AutoMapperProfile()
    {
      CreateMap<CategoryNewDto, Category>();
      CreateMap<Category, CategoriesDto>().ReverseMap();
      CreateMap<Category, DetailsCategoryDto>().ReverseMap();

      CreateMap<ProductNewDto, Product>();
      CreateMap<Product, ProductsDto>().ReverseMap();
    }

  }
}