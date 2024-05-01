using BusinessLogicLayer.Viewmodels.UserChatRooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Viewmodels.ChatRooms
{
    public class ChatRoomsCreateVM
    {
        public string CreateBy { get; set; } = null!;
        public string CodeChatRooms { get; set; } = null!;
        public string RoomName { get; set; } = null!;
        public string? Description { get; set; }
        public int Status { get; set; }
        public List<UserChatRoomsCreateVM> userChatRoomsCreateVMs { get; set; }
    }
}
