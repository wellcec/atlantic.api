using AutoMapper;
using Atlantic.Api.Data.NotificationTemplatesContext.Entities;

namespace Atlantic.Api.Models.Mapper
{
    public sealed class TemplatesMapperProfile : Profile
    {
        public TemplatesMapperProfile()
        {
            CreateMap<NotificationTemplateEntity, NotificationTemplateDTO>()
                .ForMember(dest => dest.Id, map => map.MapFrom(src => src.wtpseq))
                .ForMember(dest => dest.Template, map => map.MapFrom(src => src.wtpnomtemplate))
                .ForMember(dest => dest.StateId, map => map.MapFrom(src => src.wtpcodblcbottpl))
                .ForMember(dest => dest.PreviousTemplate, map => map.MapFrom(src => src.wtpdesprevtpl))
                .ForMember(dest => dest.NotificationType, map => map.MapFrom(src => src.wtpidttypentfcapi))
                .ForMember(dest => dest.CreatedAt, map => map.MapFrom(src => src.hdrdthins))
                .ForMember(dest => dest.UpdatedAt, map => map.MapFrom(src => src.hdrdthhor));
        }
    }
}
