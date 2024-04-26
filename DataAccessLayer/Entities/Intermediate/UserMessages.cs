using DataAccessLayer.Entities.Base;

namespace DataAccessLayer.Entities.Intermediate
{
    public partial class UserMessages : NoIDEntityBase
    {
        public string IDUser { get; set; } = null!;
        public Guid IDMessage { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Messages Messages { get; set; }
    }
}
