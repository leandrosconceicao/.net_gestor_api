using AutoMapper;
using Gestor.Domain.Entities;
using Gestor.Helpers.Models.ProductDtos;

namespace Gestor.Helpers.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<CreateProductCategoryDto, ProductCategory>();
        // CreateMap<User, ReadUserDto>();
    }
}
