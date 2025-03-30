using System.Diagnostics.CodeAnalysis;
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
        }
    }
}
