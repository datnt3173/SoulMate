using BusinessLogicLayer.Services.Interface;
using BusinessLogicLayer.Viewmodels.Information;

namespace BusinessLogicLayer.Services.Implement
{
    public class InformationService : IInformationService
    {
        public Task<bool> CreateAsync(InformationCreateVM request)
        {
            throw new NotImplementedException();
        }

        public Task<List<InformationVM>> GetAllActiveInformationAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<InformationVM>> GetAllInformationAsync()
        {
            throw new NotImplementedException();
        }

        public Task<InformationVM> GetInformationByID(Guid ID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(Guid ID, string IDUserDelete)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Guid ID, InformationUpdateVM request)
        {
            throw new NotImplementedException();
        }
    }
}
