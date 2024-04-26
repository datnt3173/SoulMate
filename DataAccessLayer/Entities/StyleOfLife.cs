using DataAccessLayer.Entities.Base;
using static DataAccessLayer.Entities.Base.EnumBase;

namespace DataAccessLayer.Entities
{
    public partial class StyleOfLife : EntityBase
    {
        public string IDUser { get; set; } = null!;
        public PetType PetType { get; set; }
        public AlcoholConsumption AlcoholConsumption { get; set; }
        public SmokingHabit SmokingHabit { get; set; }
        public DietHabit DietHabit { get; set; }
        public ExerciseHabit ExerciseHabit { get; set; }
        public SocialMediaActivityLevel SocialMediaActivityLevel { get; set; }
        public SleepHabit SleepHabit { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; } = null!;

    }
}
