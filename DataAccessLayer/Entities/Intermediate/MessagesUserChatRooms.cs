using DataAccessLayer.Entities.Base;

namespace DataAccessLayer.Entities.Intermediate
{
    public class MessagesUserChatRooms : NoIDEntityBase
    {
        public Guid IDMessages { get; set; }
        public Messages Messages { get; set; }

        public Guid IDUserChatRooms { get; set; }
        public UserChatRooms UserChatRooms { get; set; }
    }
}
