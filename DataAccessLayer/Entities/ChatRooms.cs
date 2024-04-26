using DataAccessLayer.Entities.Base;
using DataAccessLayer.Entities.Intermediate;

namespace DataAccessLayer.Entities
{
    public partial class ChatRooms : EntityBase
    {
        public string RoomName { get; set; } = null!;
        public string? Description { get; set; } 

        public virtual ICollection<UserChatRooms> UserChatRooms { get; set; }
    }
}
