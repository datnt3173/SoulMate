using BusinessLogicLayer.Viewmodels.ChatRooms;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Services.Interface
{
    public interface IChatRoomsService
    {
        Task<List<ChatRoomsVM>> GetAllInformationAsync();
        Task<List<ChatRoomsVM>> GetAllActiveInformationAsync();
        Task<ChatRoomsVM> GetInformationByID(Guid ID);
        Task<bool> CreateAsync(ChatRoomsCreateVM request);
        Task<bool> RemoveAsync(Guid ID, string IDUserDelete);
        public Task<bool> UpdateAsync(Guid ID, ChatRoomsUpdateVM request);
    }
}
