using AutoMapper;
using Gestor.Domain.Dtos.ProductDtos;
using Gestor.Domain.Entities;

namespace Gestor.Domain.Profiles
{
    public class ProductExtraProfile : Profile
    {
        public ProductExtraProfile()
        {
            CreateMap<CreateProductXExtraDto, ProductCrossExtras>();
        }
    }
}
