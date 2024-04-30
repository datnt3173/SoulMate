using static DataAccessLayer.Entities.Base.EnumBase;

namespace BusinessLogicLayer.Viewmodels.Reaction
{
    public class ReactionVM
    {
        public Guid ID { get; set; }
        public string IDUser { get; set; } = null!;
        public Guid IDPost { get; set; }
        public Guid? IDComment { get; set; }
        public ReactionType Type { get; set; }
        public int Status { get; set; }
    }
}
