
using DataAccessLayer.Entities.Base;

namespace DataAccessLayer.Entities
{
    public partial class BlockedAccount : EntityBase
    {
        public string IDUser { get; set; }
        public string IDBlockedUser { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationUser BlockedUser { get; set; }
    }
}
