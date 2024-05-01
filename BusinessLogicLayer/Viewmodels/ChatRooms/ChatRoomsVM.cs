using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Viewmodels.ChatRooms
{
    public class ChatRoomsVM
    {
        public Guid ID { get; set; }
        public string CodeChatRooms { get; set; } = null!;
        public string RoomName { get; set; } = null!;
        public string? Description { get; set; }
        public int Status { get; set; }
    }
}
