using Microsoft.AspNetCore.Http;

namespace BusinessLogicLayer.Viewmodels.Comment
{
    public class CommentCreateVM
    {
        public string CreateBy { get; set; }
        public Guid IDPost { get; set; }
        public string IDUser { get; set; } = null!;
        public List<IFormFile> ImageLink { get; set; }
        public string Text { get; set; } = null!;
        public int Status { get; set; }
    }
}
