using AutoMapper;
using Gestor.Domain.Entities;
using Gestor.Domain.Dtos;

namespace Gestor.Domain.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductCategoryDto, ProductCategory>();
        CreateMap<ProductDto.CreateProduct, Product>();
        CreateMap<ProductDto.UpdateProduct, Product>();
    }
}
