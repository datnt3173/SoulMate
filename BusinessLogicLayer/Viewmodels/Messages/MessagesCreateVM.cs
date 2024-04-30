using Microsoft.AspNetCore.Http;

namespace BusinessLogicLayer.Viewmodels.Messages
{
    public class MessagesCreateVM
    {
        public string CreateBy { get; set; }
        public string IDSender { get; set; } = null!;
        public string IDReceiver { get; set; } = null!;
        public string Content { get; set; } = null!;
        public bool IsRead { get; set; }
        public int Status { get; set; }
        public List<IFormFile> ImageLink { get; set; }

    }
}
