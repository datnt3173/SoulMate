using AutoMapper;
using BusinessLogicLayer.Viewmodels.Reaction;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.AutoMapper
{
    public class ReactionMap : Profile
    {
        public ReactionMap()
        {
            CreateMap<Reaction, ReactionVM>().ReverseMap();
        }
    }
}
