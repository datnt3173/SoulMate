using BusinessLogicLayer.Viewmodels.Information;

namespace BusinessLogicLayer.Services.Interface
{
    public interface IInformationService
    {
        Task<List<InformationVM>> GetAllInformationAsync();
        Task<List<InformationVM>> GetAllActiveInformationAsync();
        Task<InformationVM> GetInformationByID(Guid ID);
        Task<bool> CreateAsync(InformationCreateVM request);
        Task<bool> RemoveAsync(Guid ID, string IDUserDelete);
        public Task<bool> UpdateAsync(Guid ID, InformationUpdateVM request);
    }
}
