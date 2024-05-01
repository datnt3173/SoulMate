using AutoMapper;
using AutoMapper.QueryableExtensions;
using BusinessLogicLayer.Services.Interface;
using BusinessLogicLayer.Viewmodels.UserChatRooms;
using DataAccessLayer.ApplicationDBContext;
using DataAccessLayer.Entities.Intermediate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Implement
{
    public class UserChatRoomsService : IUserChatRoomsService
    {
        private readonly IMapper _mapper;
        private readonly SoulMateIdentittyDBContext _dbContext;

        public UserChatRoomsService(SoulMateIdentittyDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<bool> CreateAsync(UserChatRoomsCreateVM request)
        {
            var obj = new UserChatRooms()
            {
                CreateDate = DateTime.Now,
                ID = Guid.NewGuid(),
                IDChatRoom = request.IDChatRoom,
                IDUser = request.IDUser,
                Status = 1,
                CreateBy = request.CreateBy
            };

            await _dbContext.UserChatRooms.AddAsync(obj);
            await _dbContext.SaveChangesAsync();


            return true;
        }

        public async Task<List<UserChatRoomsVM>> GetAllActiveInformationAsync()
        {
            var list = await _dbContext.UserChatRooms
                          .Where(c => c.Status == 1)
                          .ProjectTo<UserChatRoomsVM>(_mapper.ConfigurationProvider)
                          .ToListAsync();

            return list;
        }

        public async Task<List<UserChatRoomsVM>> GetAllInformationAsync()
        {
            var list = await _dbContext.UserChatRooms
                                      .ProjectTo<UserChatRoomsVM>(_mapper.ConfigurationProvider)
                                      .ToListAsync();

            return list;
        }

        public async Task<UserChatRoomsVM> GetInformationByID(string IDUser, Guid IDChatRoom)
        {
            var UserChatRooms = await _dbContext.UserChatRooms
                            .Where(c => c.IDUser == IDUser && c.IDChatRoom == IDChatRoom)
                            .FirstOrDefaultAsync();

            if (UserChatRooms == null)
            {
                return null; // Hoặc xử lý khi không tìm thấy mục
            }

            var UserChatRoomsVM = _mapper.Map<UserChatRoomsVM>(UserChatRooms);
            return UserChatRoomsVM;
        }

        public async Task<bool> RemoveAsync(string IDUser, Guid IDChatRoom, Guid IDUserDelete)
        {
            try
            {
                var UserChatRooms = await _dbContext.UserChatRooms
                    .FirstOrDefaultAsync(c => c.IDUser == IDUser && c.IDChatRoom == IDChatRoom);

                if (UserChatRooms != null)
                {
                    UserChatRooms.Status = 0; 
                    await _dbContext.SaveChangesAsync();

                    return true;
                }
                else
                {
                    return false; 
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(string IDUser, Guid IDChatRoom, UserChatRoomsUpdateVM request)
        {
            try
            {
                var userChatRoom = await _dbContext.UserChatRooms
                    .FirstOrDefaultAsync(c => c.IDUser == IDUser && c.IDChatRoom == IDChatRoom);

                if (userChatRoom != null)
                {
                    // Update properties of userChatRoom based on request
                    userChatRoom.ModifiedBy = request.ModifiedBy;
                    userChatRoom.ModifiedDate = DateTime.Now;
                    userChatRoom.Status = request.Status;
                    userChatRoom.IDChatRoom = request.IDChatRoom;
                    // Update other properties as needed

                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false; // UserChatRooms not found
                }
            }
            catch (Exception)
            {
                return false; // Error occurred while updating
            }
        }
    }
}
