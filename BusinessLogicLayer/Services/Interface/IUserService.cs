
using BusinessLogicLayer.Viewmodels;
using BusinessLogicLayer.Viewmodels.User;

namespace BusinessLogicLayer.Services.Interface
{
    public interface IUserService
    {
        Task<List<UserDataVM>> GetAllInformationAsync();
        Task<List<UserDataVM>> GetAllActiveInformationAsync();
        Task<UserVM> GetInformationByID(string ID);
        Task<bool> RemoveAsync(string ID, string IDUserDelete);
        Task<Response> RegisterAsync(RegisterUser registerUser, string role);
        public Task<Response> Login(UserLoginModel model);
    }
}
