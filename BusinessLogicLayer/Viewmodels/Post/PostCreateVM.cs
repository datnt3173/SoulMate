using Microsoft.AspNetCore.Http;
using static DataAccessLayer.Entities.Base.EnumBase;

namespace BusinessLogicLayer.Viewmodels.Post
{
    public class PostCreateVM
    {
        public string CreateBy { get; set; } = null!;
        public string IDUser { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public PostVisibility PostVisibility { get; set; }
        public List<IFormFile> ImageLink { get; set; }
        public int Status { get; set; }
    }
}
