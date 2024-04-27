using DataAccessLayer.Entities.Base;
using DataAccessLayer.Entities.Intermediate;
using Microsoft.AspNetCore.Http.HttpResults;

namespace DataAccessLayer.Entities
{
    public partial class Messages : EntityBase
    {
        public Messages()
        {
            UserMessages = new HashSet<UserMessages>();
            SentAt = DateTime.UtcNow; // Gán giá trị mặc định cho thời gian tạo
        }
        public string IDSender { get; set; } = null!;
        public string IDReceiver { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime SentAt { get; set; }
        public bool IsRead { get; set; }
        // Thêm các thuộc tính navigation
        public virtual ApplicationUser Sender { get; set; }
        public virtual ApplicationUser Receiver { get; set; }
        public virtual ICollection<ImageData> ImageData { get; set; }
        public virtual ICollection<UserMessages> UserMessages { get; set; }
    }
}
