using BusinessLogicLayer.Services.Implement;
using BusinessLogicLayer.Services.Interface;
using BusinessLogicLayer.Viewmodels.Messages;
using Microsoft.AspNetCore.SignalR;
using NuGet.Protocol.Plugins;
using System.Threading.Tasks;

public class ChatHub : Hub
{
    private readonly IMessagesService _IMessagesService;

    public ChatHub(IMessagesService messagesService)
    {
        _IMessagesService = messagesService;
    }
    public async Task SendMessageToUser(string IDSender, string IDReceiver, MessagesCreateVM request)
    {
        try
        {
            await _IMessagesService.SendMessageToUser(IDSender, IDReceiver, request);
            await Clients.User(IDReceiver).SendAsync("ReceiveMessage", IDSender, request);
        }
        catch (Exception ex)
        {
            // Xử lý lỗi
        }
    }

    public async Task SendMessageToGroup(string IDSender, string CodeChatRooms, MessagesCreateVM request)
    {
        try
        {
            await _IMessagesService.SendMessageToGroup(IDSender, CodeChatRooms, request);
            await Clients.Group(CodeChatRooms).SendAsync("ReceiveMessage", IDSender, request);
        }
        catch (Exception ex)
        {
            // Xử lý lỗi
        }
    }

}
