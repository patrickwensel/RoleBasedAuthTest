using AutoMapper;
using WebApplication9.Data;
using WebApplication9.ViewModel;

namespace WebApplication9
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MessageDto, Message>()
               .ForMember(d => d.MessageID, o => o.MapFrom(s => s.MessageID))
               .ForMember(d => d.UserID, o => o.MapFrom(s => s.UserID))
               .ForMember(d => d.FromUserID, o => o.MapFrom(s => s.FromUserID))
               .ForMember(d => d.ToUserID, o => o.MapFrom(s => s.ToUserID))
               .ForMember(d => d.MessageText, o => o.MapFrom(s => s.MessageText))
               .ForMember(d => d.MessageDateTime, o => o.MapFrom(s => s.MessageDateTime))
               .ForMember(d => d.FromUserEmail, o => o.Ignore())
               .ForMember(d => d.ToUserEmail, o => o.Ignore())
               .ReverseMap();

        }
    }
}
