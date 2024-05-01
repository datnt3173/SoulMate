using AutoMapper;
using BusinessLogicLayer.Viewmodels.ChatRooms;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.AutoMapper
{
    public class ChatRoomsMap : Profile
    {
        public ChatRoomsMap()
        {
            CreateMap<ChatRooms, ChatRoomsVM>().ReverseMap();
        }
    }
}
