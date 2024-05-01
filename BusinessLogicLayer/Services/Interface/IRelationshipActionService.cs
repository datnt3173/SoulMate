using BusinessLogicLayer.Viewmodels.RelationshipAction;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Services.Interface
{
    public interface IRelationshipActionService
    {
        Task<List<RelationshipActionVM>> GetAllRelationshipActionsAsync();
        Task<RelationshipActionVM> GetRelationshipActionByIDAsync(Guid ID);
        Task<bool> CreateRelationshipActionAsync(RelationshipActionCreateVM request);
        Task<bool> UpdateRelationshipActionAsync(Guid ID, RelationshipActionUpdateVM request);
        Task<bool> DeleteRelationshipActionAsync(Guid ID);
    }
}
