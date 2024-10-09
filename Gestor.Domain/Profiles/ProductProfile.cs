using AutoMapper;
using Gestor.Domain.Entities;
using Gestor.Domain.Dtos.ProductDtos;

namespace Gestor.Domain.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<CreateProductCategoryDto, ProductCategory>();
        CreateMap<CreateProductDto, Product>();
        // CreateMap<User, ReadUserDto>();
    }
}
