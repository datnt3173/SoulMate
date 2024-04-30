namespace BusinessLogicLayer.Viewmodels.Comment
{
    public class CommentUpdateVM
    {
        public string ModifiedBy { get; set; }
        public Guid IDPost { get; set; }
        public string IDUser { get; set; } = null!;
        public List<string> ImageLink { get; set; }
        public string Text { get; set; } = null!;
        public int Status { get; set; }
    }
}
