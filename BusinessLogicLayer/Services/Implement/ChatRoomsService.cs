using AutoMapper;
using BusinessLogicLayer.Services.Interface;
using BusinessLogicLayer.Viewmodels.ChatRooms;
using DataAccessLayer.ApplicationDBContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Entities.Intermediate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Implement
{
    public class ChatRoomsService : IChatRoomsService
    {
        private readonly IMapper _mapper;
        private readonly SoulMateIdentittyDBContext _dbContext;

        public ChatRoomsService(SoulMateIdentittyDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<bool> CreateAsync(ChatRoomsCreateVM request)
        {
            try
            {
                var newChatRoom = new ChatRooms
                {
                    ID = Guid.NewGuid(),
                    CodeChatRooms = request.CodeChatRooms,
                    RoomName = request.RoomName,
                    Description = request.Description,
                    Status = 1,
                    CreateBy = request.CreateBy,
                    CreateDate = DateTime.Now
                };

                _dbContext.ChatRooms.Add(newChatRoom);

                foreach (var userChatRoom in request.userChatRoomsCreateVMs)
                {
                    var newUserChatRoom = new UserChatRooms
                    {
                        ID = Guid.NewGuid(),
                        IDUser = userChatRoom.IDUser,
                        IDChatRoom = newChatRoom.ID,
                        Status = 1, // Trạng thái mặc định
                        CreateDate = DateTime.Now,
                        CreateBy = request.CreateBy
                    };

                    _dbContext.UserChatRooms.Add(newUserChatRoom);
                }

                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<ChatRoomsVM>> GetAllActiveInformationAsync()
        {
            var chatRooms = await _dbContext.ChatRooms
                .Where(c => c.Status == 1)
                .ToListAsync();

            return _mapper.Map<List<ChatRoomsVM>>(chatRooms);
        }

        public async Task<List<ChatRoomsVM>> GetAllInformationAsync()
        {
            var chatRooms = await _dbContext.ChatRooms.ToListAsync();
            return _mapper.Map<List<ChatRoomsVM>>(chatRooms);
        }

        public async Task<ChatRoomsVM> GetInformationByID(Guid ID)
        {
            var chatRoom = await _dbContext.ChatRooms.FindAsync(ID);
            return _mapper.Map<ChatRoomsVM>(chatRoom);
        }

        public async Task<bool> RemoveAsync(Guid ID, string IDUserDelete)
        {
            try
            {
                var chatRoom = await _dbContext.ChatRooms.FindAsync(ID);
                if (chatRoom == null)
                    return false;

                _dbContext.ChatRooms.Remove(chatRoom);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Handle exception
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Guid ID, ChatRoomsUpdateVM request)
        {
            try
            {
                var chatRoom = await _dbContext.ChatRooms.FindAsync(ID);
                if (chatRoom == null)
                    return false;

                _mapper.Map(request, chatRoom);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Handle exception
                return false;
            }
        }
    }
}
