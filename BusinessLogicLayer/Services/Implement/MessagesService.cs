using AutoMapper;
using BusinessLogicLayer.Services.Interface;
using BusinessLogicLayer.Viewmodels.Messages;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using DataAccessLayer.ApplicationDBContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Entities.Intermediate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Implement
{
    public class MessagesService : IMessagesService
    {
        private readonly Cloudinary _cloudinary;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly SoulMateIdentittyDBContext _dbContext;
        public MessagesService(SoulMateIdentittyDBContext SoulMateIdentittyDBContext,
            UserManager<ApplicationUser> userManager, Cloudinary Cloudinary,
            IMapper IMapper)
        {
            _cloudinary = Cloudinary;
            _mapper = IMapper;
            _userManager = userManager;
            _dbContext = SoulMateIdentittyDBContext;
        }

        public async Task<List<MessagesVM>> GetMessagesBetweenUsers(string IDSender, string IDReceiver)
        {
            var messages = await _dbContext.Messages
                           .Where(m => (m.IDSender == IDSender && m.IDReceiver == IDReceiver) ||
                                       (m.IDSender == IDReceiver && m.IDReceiver == IDSender))
                           .ToListAsync();

            return _mapper.Map<List<MessagesVM>>(messages);
        }

        public async Task<List<MessagesVM>> GetMessagesForGroup(string CodeChatRooms)
        {
            var messages = await _dbContext.Messages
                 .Include(m => m.MessagesUserChatRooms)
                     .ThenInclude(mucr => mucr.UserChatRooms)
                         .ThenInclude(ur => ur.ChatRooms)
                 .Where(m => m.MessagesUserChatRooms.Any(mucr => mucr.UserChatRooms.ChatRooms.CodeChatRooms == CodeChatRooms))
                 .ToListAsync();

            return _mapper.Map<List<MessagesVM>>(messages);
        }

        public async Task<List<MessagesVM>> GetMessagesForUser(string IDUser)
        {
            var messages = await _dbContext.Messages
                           .Where(m => m.IDSender == IDUser || m.IDReceiver == IDUser)
                           .ToListAsync();

            return _mapper.Map<List<MessagesVM>>(messages);
        }

        public async Task<List<MessagesVM>> GetMessagesFromUserToGroup(string IDSender, string CodeChatRooms)
        {
            var messages = await _dbContext.Messages
                           .Include(m => m.MessagesUserChatRooms)
                               .ThenInclude(mucr => mucr.UserChatRooms)
                           .Where(m => m.IDSender == IDSender && m.MessagesUserChatRooms.Any(mucr => mucr.UserChatRooms.ChatRooms.CodeChatRooms == CodeChatRooms))
                           .ToListAsync();

            return _mapper.Map<List<MessagesVM>>(messages);
        }

        public async Task SendMessageToGroup(string IDSender, string CodeChatRooms, MessagesCreateVM request)
        {
            var sender = await _dbContext.Users.FindAsync(IDSender);
            if (sender == null)
            {
                throw new ArgumentException("Sender not found");
            }

            // Tạo tin nhắn mới
            var message = new Messages
            {
                ID = Guid.NewGuid(),
                IDSender = IDSender,
                Content = request.Content,
                SentAt = DateTime.UtcNow,
                IsRead = false,
                Status = 1,
                CreateBy = request.IDSender,
                CreateDate = DateTime.Now
            };

            // Lưu tin nhắn vào cơ sở dữ liệu
            _dbContext.Messages.Add(message);
            await _dbContext.SaveChangesAsync();

            // Tìm phòng trò chuyện trong cơ sở dữ liệu
            var chatRoom = await _dbContext.ChatRooms.FirstOrDefaultAsync(cr => cr.CodeChatRooms == CodeChatRooms);
            if (chatRoom == null)
            {
                throw new ArgumentException("Chat room not found");
            }

            // Tạo liên kết giữa tin nhắn và phòng trò chuyện
            var messageUserChatRoom = new MessagesUserChatRooms
            {
                IDMessages = message.ID,
                IDUserChatRooms = chatRoom.ID
            };

            // Lưu liên kết vào cơ sở dữ liệu
            _dbContext.MessagesUserChatRooms.Add(messageUserChatRoom);
            await _dbContext.SaveChangesAsync();

            // Upload ảnh lên Cloudinary và lưu link vào cơ sở dữ liệu
            foreach (var file in request.ImageLink)
            {
                var uploadResult = await UploadImageToCloudinary(file);
                var imageData = new ImageData
                {
                    ID = Guid.NewGuid(),
                    IDComment = null,
                    IDPost = null,
                    IDUser = null,
                    IDMessage = message.ID,
                    ImageLink = uploadResult.SecureUrl.AbsoluteUri,
                    Status = 1,
                    CreateBy = request.IDSender,
                    CreateDate = DateTime.Now
                };
                _dbContext.ImageData.Add(imageData);
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task SendMessageToUser(string IDSender, string IDReceiver, MessagesCreateVM request)
        {
            var sender = await _dbContext.Users.FindAsync(IDSender);
            var receiver = await _dbContext.Users.FindAsync(IDReceiver);
            if (sender == null || receiver == null)
            {
                throw new ArgumentException("Sender or receiver not found");
            }

            // Tạo tin nhắn mới
            var message = new Messages
            {
                ID = Guid.NewGuid(),
                IDSender = IDSender,
                IDReceiver = IDReceiver,
                Content = request.Content,
                SentAt = DateTime.UtcNow,
                IsRead = false,
                Status = 1,
                CreateBy = request.IDSender,
                CreateDate = DateTime.Now
            };

            // Lưu tin nhắn vào cơ sở dữ liệu
            _dbContext.Messages.Add(message);
            await _dbContext.SaveChangesAsync();

            // Upload ảnh lên Cloudinary và lưu link vào cơ sở dữ liệu
            foreach (var file in request.ImageLink)
            {
                var uploadResult = await UploadImageToCloudinary(file);
                var imageData = new ImageData
                {
                    ID = Guid.NewGuid(),
                    IDComment = null,
                    IDPost = null,
                    IDUser = null,
                    IDMessage = message.ID,
                    ImageLink = uploadResult.SecureUrl.AbsoluteUri,
                    Status = 1,
                    CreateBy = request.IDSender,
                    CreateDate = DateTime.Now
                };
                _dbContext.ImageData.Add(imageData);
            }

            await _dbContext.SaveChangesAsync();
        }
        private async Task<ImageUploadResult> UploadImageToCloudinary(IFormFile file)
        {
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, file.OpenReadStream())
            };
            var uploadResult = await _cloudinary.UploadAsync(uploadParams);
            return uploadResult;
        }
    }
}
