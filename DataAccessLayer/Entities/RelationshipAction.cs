using DataAccessLayer.Entities.Base;
using static DataAccessLayer.Entities.Base.EnumBase;

namespace DataAccessLayer.Entities
{
    public class RelationshipAction : EntityBase
    {
        public string IDUser { get; set; } = null!;
        public string IDRelatedUser{ get; set; } = null!;
        public ActionType ActionType { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationUser RelatedUser { get; set; }
    }
}
