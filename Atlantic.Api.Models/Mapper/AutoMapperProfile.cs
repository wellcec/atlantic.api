using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

using AutoMapper;

namespace Atlantic.Api.Models.Mapper
{
    [ExcludeFromCodeCoverage]
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //CreateMap<ProductLinx, Product>()
            //    .ForMember(dest => dest.Id, map => map.MapFrom(src => src.Id))
            //    .ForMember(dest => dest.Name, map => map.MapFrom(src => src.Name))
            //    .ForMember(dest => dest.Description, map => map.MapFrom(src => src.Description))
            //    .ForMember(dest => dest.OriginalValue, map => map.MapFrom(src => src.OldPrice))
            //    .ForMember(dest => dest.CurrentValue, map => map.MapFrom(src => src.Price))
            //    .ForMember(dest => dest.Category, map => map.MapFrom(src => src.Categories.First(c => !c.Parents.Any()).Name))
            //    .ForMember(dest => dest.Brand, map => map.MapFrom(src => src.Details.Brand.First()))
            //    .ForMember(dest => dest.UnitQuantity, map => map.MapFrom(src => src.Details.Measurement.First().Multiplier))
            //    .ForMember(dest => dest.UnitType, map => map.MapFrom(src => src.Details.Measurement.First().Unit))
            //    .ForMember(dest => dest.Sku, map => map.MapFrom(src => GetSKU(src)))
            //    .ForMember(dest => dest.RestrictedSale, map => map.MapFrom(src => src.Details.RestrictedSale.Any(c=> c.Contains(PRESCRIPTION_ALERT))))
            //    .ForMember(dest => dest.Images, map => map.MapFrom(src => new List<Image>()
            //                                                              {
            //                                                                    new Image()
            //                                                                    {
            //                                                                        ImageUrl = HTTPS + src.Images.Size_200x200,
            //                                                                        Order = 1
            //                                                                    }
            //                                                              }));

        }
    }
}
