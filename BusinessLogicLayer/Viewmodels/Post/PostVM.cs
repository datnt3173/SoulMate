using static DataAccessLayer.Entities.Base.EnumBase;

namespace BusinessLogicLayer.Viewmodels.Post
{
    public class PostVM
    {
        public Guid ID { get; set; }
        public string IDUser { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public PostVisibility PostVisibility { get; set; }
        public int LikeCount { get; set; }
        public int CommentCount { get; set; }
        public List<string> ImageLink { get; set; } 
        public int Status { get; set; }
    }
}
