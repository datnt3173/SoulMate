using BusinessLogicLayer.Viewmodels.UserChatRooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interface
{
    public interface IUserChatRoomsService
    {
        public Task<List<UserChatRoomsVM>> GetAllInformationAsync();
        public Task<List<UserChatRoomsVM>> GetAllActiveInformationAsync();
        public Task<UserChatRoomsVM> GetInformationByID(string IDUser, Guid IDChatRoom);
        public Task<bool> CreateAsync(UserChatRoomsCreateVM request);
        public Task<bool> RemoveAsync(string IDUser, Guid IDChatRoom, Guid IDUserDelete);
        public Task<bool> UpdateAsync(string IDUser, Guid IDChatRoom, UserChatRoomsUpdateVM request);
    }
}
