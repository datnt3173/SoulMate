
namespace BusinessLogicLayer.Services.Interface
{
    public class CommentVM
    {
        public Guid ID { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateBy { get; set; }
        public Guid IDPost { get; set; }
        public string IDUser { get; set; } = null!;
        public List<string> ImageLink { get; set; }
        public string Text { get; set; } = null!;
        public int Status { get; set; }
    }
}
