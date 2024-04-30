using DataAccessLayer.Entities.Base;
namespace DataAccessLayer.Entities
{
    public partial class Comment : EntityBase
    {
        public Guid IDPost { get; set; } 
        public string IDUser { get; set; } = null!;
        //public Guid IDParentComment { get; set; }
        public string Text { get; set; } = null!;
        public virtual Post Post { get; set; } = null!;
        public virtual ICollection<Reaction> Reaction { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<ImageData> ImageData { get; set; }

    }
}
