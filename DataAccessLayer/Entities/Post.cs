using DataAccessLayer.Entities.Base;
using static DataAccessLayer.Entities.Base.EnumBase;

namespace DataAccessLayer.Entities
{
    public partial class Post : EntityBase
    {
        public string IDUser { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public PostVisibility PostVisibility { get; set; } 
        public virtual ICollection<Comment> Comment { get; set; } 
        public virtual ICollection<Reaction> Reaction { get; set; } 
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<ImageData> ImageData { get; set; }

    }
}
