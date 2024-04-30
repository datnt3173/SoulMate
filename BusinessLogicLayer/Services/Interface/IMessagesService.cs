using BusinessLogicLayer.Viewmodels.Messages;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Services.Interface
{
    public interface IMessagesService
    {
        // Gửi tin nhắn từ một người dùng đến một người dùng khác
        Task SendMessageToUser(string IDSender, string IDReceiver, MessagesCreateVM request);

        // Gửi tin nhắn từ một người dùng đến một nhóm người dùng
        Task SendMessageToGroup(string IDSender, string CodeChatRooms, MessagesCreateVM request);

        // Lấy tất cả tin nhắn gửi đến một người dùng
        Task<List<MessagesVM>> GetMessagesForUser(string IDUser);

        // Lấy tất cả tin nhắn trong một nhóm
        Task<List<MessagesVM>> GetMessagesForGroup(string CodeChatRooms);

        // Lấy tất cả tin nhắn gửi từ một người dùng đến một người dùng khác
        Task<List<MessagesVM>> GetMessagesBetweenUsers(string IDSender, string IDReceiver);

        // Lấy tất cả tin nhắn gửi từ một người dùng đến một nhóm người dùng
        Task<List<MessagesVM>> GetMessagesFromUserToGroup(string IDSender, string CodeChatRooms);
    }
}
