using BusinessLogicLayer.Viewmodels.Comment;

namespace BusinessLogicLayer.Services.Interface
{
    public interface ICommentService
    {
        Task<List<CommentVM>> GetAllInformationAsync();
        Task<List<CommentVM>> GetAllActiveInformationAsync();
        Task<CommentVM> GetInformationByID(Guid ID);
        Task<bool> CreateAsync(CommentCreateVM request);
        Task<bool> RemoveAsync(Guid ID, string IDUserDelete);
        public Task<bool> UpdateAsync(Guid ID, CommentUpdateVM request);

    }
}
