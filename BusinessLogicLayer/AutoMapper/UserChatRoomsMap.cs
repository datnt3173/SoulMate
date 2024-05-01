using AutoMapper;
using BusinessLogicLayer.Viewmodels.UserChatRooms;
using DataAccessLayer.Entities.Intermediate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.AutoMapper
{
    public class UserChatRoomsMap : Profile
    {
        public UserChatRoomsMap()
        {
            CreateMap<UserChatRooms, UserChatRoomsVM>().ReverseMap();
        }
    }
}
