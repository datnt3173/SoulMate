using BusinessLogicLayer.Viewmodels.Reaction;
using static DataAccessLayer.Entities.Base.EnumBase;

namespace BusinessLogicLayer.Services.Interface
{
    public interface IReactionService
    {
        Task<List<ReactionVM>> GetAllInformationAsync();
        Task<List<ReactionVM>> GetAllActiveInformationAsync();
        Task<ReactionVM> GetInformationByID(Guid ID);
        Task<bool> CreateAsync(ReactionCreateVM request);
        Task<bool> RemoveAsync(Guid ID);
        Task<bool> UpdateAsync(Guid IDReaction, ReactionType newType);
    }
}
