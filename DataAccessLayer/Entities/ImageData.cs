using DataAccessLayer.Entities.Base;

namespace DataAccessLayer.Entities
{
    public partial class ImageData : EntityBase
    {
        public Guid? IDMessage {  get; set; }
        public Guid? IDPost {  get; set; }
        public Guid? IDComment {  get; set; }
        public string? IDUser {  get; set; }
        public string ImageLink { get; set; }
        public byte[]? EncodedImage { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Post Post { get; set; }
        public virtual Comment Comment { get; set; }
        public virtual Messages Messages { get; set; }

    }
}
