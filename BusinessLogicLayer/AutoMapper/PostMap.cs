using AutoMapper;
using BusinessLogicLayer.Viewmodels.Post;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.AutoMapper
{
    public class PostMap : Profile
    {
        public PostMap()
        {
            CreateMap<Post, PostVM>().ReverseMap();
        }
    }
}
