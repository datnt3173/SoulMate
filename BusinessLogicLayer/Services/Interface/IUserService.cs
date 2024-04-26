
using BusinessLogicLayer.Viewmodels;
using BusinessLogicLayer.Viewmodels.User;

namespace BusinessLogicLayer.Services.Interface
{
    public interface IUserService
    {
        //Task<List<UserVM>> GetAllInformationAsync();
        //Task<List<UserVM>> GetAllActiveInformationAsync();
        //Task<UserVM> GetInformationByID(string ID);
        //Task<bool> RemoveAsync(string ID, Guid IDUserDelete);
        Task<Response> RegisterAsync(RegisterUser registerUser, string role);
        public Task<Response> Login(UserLoginModel model);
    }
}
