using DataAccessLayer.Entities.Base;
using static DataAccessLayer.Entities.Base.EnumBase;

namespace DataAccessLayer.Entities
{
    public partial class Reaction : EntityBase
    {
        public string IDUser { get; set; } = null!;
        public Guid IDPost { get; set; } 
        public Guid IDComment { get; set; } 
        public ReactionType Type { get; set; }
        public virtual Post Post { get; set; } = null!;
        public virtual Comment Comment { get; set; } = null!;
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<ImageData> ImageData { get; set; }

    }
}
