﻿using AutoMapper;
using Gestor.Domain.Dtos;
using Gestor.Domain.Entities;

namespace Gestor.Domain.Profiles
{
    public class ProductExtraProfile : Profile
    {
        public ProductExtraProfile()
        {
            CreateMap<ProductXExtraDto, ProductCrossExtras>();
        }
    }
}
