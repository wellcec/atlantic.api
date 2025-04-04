﻿using System.Diagnostics.CodeAnalysis;
using Atlantic.Api.Models.Context.Products;
using Atlantic.Api.Models.DTOs;
using AutoMapper;

namespace Atlantic.Api.Models.Mapper
{
    [ExcludeFromCodeCoverage]
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Category, CategoryDTO>()
                .ForMember(dest => dest.id, map => map.MapFrom(src => src.id.ToString()));

            CreateMap<Variation, VariationDTO>()
                .ForMember(dest => dest.id, map => map.MapFrom(src => src.id.ToString()));

            CreateMap<Image, ImageDTO>()
                .ForMember(dest => dest.id, map => map.MapFrom(src => src.id.ToString()));

            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.id, map => map.MapFrom(src => src.id.ToString()))
                .ForMember(dest => dest.categories, map => map.MapFrom(src => src.categories))
                .ForMember(dest => dest.variations, map => map.MapFrom(src => src.variations))
                .ForMember(dest => dest.images, map => map.MapFrom(src => src.images));
        }
    }
}
