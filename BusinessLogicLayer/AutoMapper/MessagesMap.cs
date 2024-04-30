using AutoMapper;
using BusinessLogicLayer.Viewmodels.Messages;
using DataAccessLayer.Entities;
using System.Linq;

namespace BusinessLogicLayer.AutoMapper
{
    public class MessagesMap : Profile
    {
        public MessagesMap()
        {
            CreateMap<Messages, MessagesVM>()
               .ForMember(dest => dest.ImageLink, opt => opt.MapFrom(src => src.ImageData.Select(c=>c.ImageLink)))
               .ReverseMap();
        }
    }
}
