using DataAccessLayer.Entities.Intermediate;
using Microsoft.AspNetCore.Identity;

namespace DataAccessLayer.Entities
{
    public partial class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            SentMessages = new HashSet<Messages>();
            ReceivedMessages = new HashSet<Messages>();
            UserMessages = new HashSet<UserMessages>();
        }
        public bool IsActive { get; set; } = true;
        public int Status { get; set; } = 1;

        public virtual ICollection<UserChatRooms> UserChatRooms { get; set; }
        public virtual ICollection<UserMessages> UserMessages { get; set; }
        public virtual ExtraInformation ExtraInformation { get; set; }
        public virtual StyleOfLife StyleOfLife { get; set; }
        public virtual Information Information { get; set; }
        public virtual ICollection<Messages> SentMessages { get; set; }
        public virtual ICollection<Messages> ReceivedMessages { get; set; }
    }
}