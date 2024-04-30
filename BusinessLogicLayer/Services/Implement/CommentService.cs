using AutoMapper;
using BusinessLogicLayer.Services.Interface;
using BusinessLogicLayer.Viewmodels.Comment;
using BusinessLogicLayer.Viewmodels.Post;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using DataAccessLayer.ApplicationDBContext;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static DataAccessLayer.Entities.Base.EnumBase;

namespace BusinessLogicLayer.Services.Implement
{
    public class CommentService : ICommentService
    {
        private readonly Cloudinary _cloudinary;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly SoulMateIdentittyDBContext _dbContext;
        public CommentService(SoulMateIdentittyDBContext SoulMateIdentittyDBContext,
            UserManager<ApplicationUser> userManager, Cloudinary Cloudinary,
            IMapper IMapper)
        {
            _cloudinary = Cloudinary;
            _mapper = IMapper;
            _userManager = userManager;
            _dbContext = SoulMateIdentittyDBContext;
        }

        public async Task<bool> CreateAsync(CommentCreateVM request)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                var comment = new Comment()
                {
                    ID = Guid.NewGuid(),
                    IDUser = request.IDUser,
                    IDPost = request.IDPost,
                    Text = request.Text,
                    Status = request.Status,
                    CreateBy = request.CreateBy,
                    CreateDate = DateTime.Now,
                };

                _dbContext.Comment.Add(comment);
                await _dbContext.SaveChangesAsync();

                var commentid = comment.ID;

                if (request.ImageLink != null && request.ImageLink.Any())
                {
                    foreach (var formFile in request.ImageLink)
                    {
                        var uploadParams = new ImageUploadParams()
                        {
                            File = new FileDescription(formFile.FileName, formFile.OpenReadStream())
                        };

                        var uploadResult = await _cloudinary.UploadAsync(uploadParams);

                        if (uploadResult.Error != null)
                        {
                            throw new Exception($"Error uploading image: {uploadResult.Error.Message}");
                        }

                        var image = new ImageData()
                        {
                            ID = Guid.NewGuid(),
                            IDComment = commentid,
                            IDMessage = null,
                            IDUser = null,
                            IDPost = null,
                            ImageLink = uploadResult.SecureUri.AbsoluteUri,
                            CreateBy = request.IDUser,
                            CreateDate = DateTime.Now,
                            Status = 1
                        };

                        _dbContext.ImageData.Add(image);
                        await _dbContext.SaveChangesAsync();
                    }
                }

                await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                // Log the exception or handle it appropriately
                return false;
            }
        }

        public async Task<List<CommentVM>> GetAllActiveInformationAsync()
        {
            var activeComment = await _dbContext.Comment
                                       .Where(p => p.Status == 1)
                                       .OrderByDescending(p => p.CreateDate)
                                       .Include(p => p.ApplicationUser)
                                       .Include(p => p.ImageData)
                                       .Include(p => p.Post)
                                       .Select(p => new CommentVM
                                       {
                                           CreateBy = p.CreateBy,
                                           CreateDate = p.CreateDate,
                                           ID = p.ID,
                                           IDUser = p.IDUser,
                                           IDPost = p.ID,
                                           Text = p.Text,
                                           ImageLink = p.ImageData.Select(i => i.ImageLink).ToList(),
                                           Status = p.Status
                                       })
                                       .ToListAsync();

            return activeComment;
        }

        public async Task<List<CommentVM>> GetAllInformationAsync()
        {
            var activeComment = await _dbContext.Comment
                                                 .OrderByDescending(p => p.CreateDate)
                                                 .Include(p => p.ApplicationUser)
                                                 .Include(p => p.ImageData)
                                                 .Include(p => p.Post)
                                                 .Select(p => new CommentVM
                                                 {
                                                     CreateBy = p.CreateBy,
                                                     CreateDate = p.CreateDate,
                                                     ID = p.ID,
                                                     IDUser = p.IDUser,
                                                     IDPost = p.ID,
                                                     Text = p.Text,
                                                     ImageLink = p.ImageData.Select(i => i.ImageLink).ToList(),
                                                     Status = p.Status
                                                 })
                                                 .ToListAsync();

            return activeComment;
        }

        public async Task<CommentVM> GetInformationByID(Guid ID)
        {
            var activeComment = await _dbContext.Comment
                           .Where(p => p.ID == ID)
                           .Include(p => p.ApplicationUser) // Join để lấy thông tin người dùng
                           .Include(p => p.ImageData) // Join để lấy thông tin hình ảnh
                           .FirstOrDefaultAsync();

            if (activeComment == null)
            {
                return null;
            }

            var comment = new CommentVM
            {
                CreateBy = activeComment.CreateBy,
                CreateDate = activeComment.CreateDate,
                ID = activeComment.ID,
                IDUser = activeComment.IDUser,
                IDPost = activeComment.IDPost,
                Text = activeComment.Text,
                ImageLink = activeComment.ImageData.Select(i => i.ImageLink).ToList(),
                Status = activeComment.Status
            };

            return comment;
        }

        public async Task<bool> RemoveAsync(Guid ID, string IDUserDelete)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var obj = await _dbContext.Comment.FirstOrDefaultAsync(c => c.ID == ID);

                    if (obj != null)
                    {
                        obj.Status = 0;
                        obj.DeleteDate = DateTime.Now;
                        obj.DeleteBy = IDUserDelete;

                        _dbContext.Comment.Attach(obj);
                        await _dbContext.SaveChangesAsync();


                        transaction.Commit();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public async Task<bool> UpdateAsync(Guid ID, CommentUpdateVM request)
        {
            try
            {
                // Tìm bình luận cần cập nhật trong cơ sở dữ liệu
                var comment = await _dbContext.Comment.FirstOrDefaultAsync(c => c.ID == ID);

                if (comment == null)
                {
                    // Nếu không tìm thấy bình luận, trả về false
                    return false;
                }

                // Cập nhật các trường thông tin của bình luận
                comment.ModifiedBy = request.ModifiedBy;
                comment.ModifiedDate = DateTime.Now;
                comment.Text = request.Text;
                comment.Status = request.Status;

                // Cập nhật ảnh của bình luận
                if (request.ImageLink != null && request.ImageLink.Any())
                {
                    // Xóa tất cả các ảnh cũ của bình luận
                    _dbContext.ImageData.RemoveRange(comment.ImageData);

                    // Thêm các ảnh mới vào bình luận
                    foreach (var imageLink in request.ImageLink)
                    {
                        var imageData = new ImageData
                        {
                            ImageLink = imageLink
                        };
                        comment.ImageData.Add(imageData);
                    }
                }

                // Lưu thay đổi vào cơ sở dữ liệu
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                // Xử lý các trường hợp ngoại lệ
                return false;
            }
        }
    }
}
