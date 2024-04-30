using BusinessLogicLayer.Viewmodels.Post;
using static DataAccessLayer.Entities.Base.EnumBase;

namespace BusinessLogicLayer.Services.Interface
{
    public interface IPostService
    {
        Task<List<PostVM>> GetAllInformationAsync();
        Task<List<PostVM>> GetAllActiveInformationAsync();
        Task<PostVM> GetInformationByID(Guid ID);
        Task<bool> CreateAsync(PostCreateVM request);
        Task<bool> RemoveAsync(Guid ID, string IDUserDelete);
        Task<bool> UpdateAsync(Guid ID, PostUpdateVM request);
        Task<bool> ChangeVisibilityAsync(Guid IDPost, PostVisibility newVisibility);

    }
}
