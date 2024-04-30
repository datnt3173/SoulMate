using static DataAccessLayer.Entities.Base.EnumBase;

namespace BusinessLogicLayer.Viewmodels.Reaction
{
    public class ReactionCreateVM
    {
        public string CreateBy { get; set; } = null!;
        public string IDUser { get; set; } = null!;
        public Guid IDPost { get; set; }
        public Guid? IDComment { get; set; }
        public ReactionType Type { get; set; }
        public int Status { get; set; }
    }
}
