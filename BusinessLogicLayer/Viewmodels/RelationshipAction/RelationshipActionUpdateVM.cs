using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccessLayer.Entities.Base.EnumBase;

namespace BusinessLogicLayer.Viewmodels.RelationshipAction
{
    public class RelationshipActionUpdateVM
    {
        public string ModifiedBy { get; set; }

        public string IDUser { get; set; } = null!;
        public string IDRelatedUser { get; set; } = null!;
        public ActionType ActionType { get; set; }
        public int Status { get; set; }
    }
}
