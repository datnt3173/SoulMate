using DataAccessLayer.Entities.Base;

namespace DataAccessLayer.Entities.Intermediate
{
    public partial class UserChatRooms : NoIDEntityBase
    {
        public string IDUser { get; set; } = null!;
        public Guid IDChatRoom { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ChatRooms ChatRooms { get; set; }
    }
}
