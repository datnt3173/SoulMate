using DataAccessLayer.Entities.Base;
using static DataAccessLayer.Entities.Base.EnumBase;

namespace DataAccessLayer.Entities
{
    public partial class ExtraInformation : EntityBase
    {
        public string IDUser { get; set; } 
        public Zodiac Zodiac { get; set; }
        public AcademicLevel AcademicLevel { get; set; }
        public PersonalityType PersonalityType { get; set; }
        public ChildDesire ChildDesire { get; set; }
        public CommunicationStyle CommunicationStyle { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; } 
    }
}
