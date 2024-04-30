using AutoMapper;
using BusinessLogicLayer.Services.Interface;
using BusinessLogicLayer.Viewmodels.Post;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using DataAccessLayer.ApplicationDBContext;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static DataAccessLayer.Entities.Base.EnumBase;

namespace BusinessLogicLayer.Services.Implement
{
    public class PostService : IPostService
    {
        private readonly Cloudinary _cloudinary;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly SoulMateIdentittyDBContext _dbContext;
        public PostService(SoulMateIdentittyDBContext SoulMateIdentittyDBContext,
            UserManager<ApplicationUser> userManager, Cloudinary Cloudinary,
            IMapper IMapper)
        {
            _cloudinary = Cloudinary;
            _mapper = IMapper;
            _userManager = userManager;
            _dbContext = SoulMateIdentittyDBContext;
        }

        public async Task<bool> CreateAsync(PostCreateVM request)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                var post = new Post()
                {
                    ID = Guid.NewGuid(),
                    IDUser = request.IDUser,
                    Title = request.Title,
                    Content = request.Content,
                    PostVisibility = request.PostVisibility,
                    Status = request.Status,
                    CreateBy = request.CreateBy,
                    CreateDate = DateTime.Now,
                };

                _dbContext.Post.Add(post);
                await _dbContext.SaveChangesAsync();

                // Use the ID of the newly created post
                var postId = post.ID;

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
                            IDComment = null,
                            IDMessage = null,
                            IDUser = null,
                            IDPost = postId, // Use the ID of the newly created post
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
        public async Task<List<PostVM>> GetAllActiveInformationAsync()
        {
            var activePosts = await _dbContext.Post
                           .Where(p => p.Status == 1 && p.PostVisibility == PostVisibility.Public)
                           .OrderByDescending(p => p.CreateDate)
                           .Include(p => p.ApplicationUser) // Join để lấy thông tin người dùng
                           .Include(p => p.ImageData) // Join để lấy thông tin hình ảnh
                           .Select(p => new PostVM
                           {
                               ID = p.ID,
                               IDUser = p.IDUser,
                               Title = p.Title,
                               Content = p.Content,
                               PostVisibility = p.PostVisibility,
                               LikeCount = p.Reaction.Count, // Đếm số lượt like
                               CommentCount = p.Comment.Count, // Đếm số lượt comment
                               ImageLink = p.ImageData.Select(i => i.ImageLink).ToList(),
                               Status = p.Status
                           })
                           .ToListAsync();

            return activePosts;
        }
        public async Task<List<PostVM>> GetAllInformationAsync()
        {
            var activePosts = await _dbContext.Post
                                      .OrderByDescending(p => p.CreateDate)
                                      .Include(p => p.ApplicationUser) // Join để lấy thông tin người dùng
                                      .Include(p => p.ImageData) // Join để lấy thông tin hình ảnh
                                      .Select(p => new PostVM
                                      {
                                          ID = p.ID,
                                          IDUser = p.IDUser,
                                          Title = p.Title,
                                          Content = p.Content,
                                          PostVisibility = p.PostVisibility,
                                          LikeCount = p.Reaction.Count, // Đếm số lượt like
                                          CommentCount = p.Comment.Count, // Đếm số lượt comment
                                          ImageLink = p.ImageData.Select(i => i.ImageLink).ToList(),
                                          Status = p.Status
                                      })
                                      .ToListAsync();

            return activePosts;
        }
        public async Task<PostVM> GetInformationByID(Guid ID)
        {
            var post = await _dbContext.Post
               .Where(p => p.ID == ID)
               .Include(p => p.ApplicationUser) // Join để lấy thông tin người dùng
               .Include(p => p.ImageData) // Join để lấy thông tin hình ảnh
               .FirstOrDefaultAsync();

            if (post == null)
            {
                return null;
            }

            var postVM = new PostVM
            {
                ID = post.ID,
                IDUser = post.IDUser,
                Title = post.Title,
                Content = post.Content,
                PostVisibility = post.PostVisibility,
                LikeCount = post.Reaction.Count, // Đếm số lượt like
                CommentCount = post.Comment.Count, // Đếm số lượt comment
                Status = post.Status,
                ImageLink = post.ImageData.Select(image => image.ImageLink).ToList() 
            };

            return postVM;
        }
        public async Task<bool> RemoveAsync(Guid ID, string IDUserDelete)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var obj = await _dbContext.Post.FirstOrDefaultAsync(c => c.ID == ID);

                    if (obj != null)
                    {
                        obj.Status = 0;
                        obj.DeleteDate = DateTime.Now;
                        obj.DeleteBy = IDUserDelete;

                        _dbContext.Post.Attach(obj);
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

        public Task<bool> UpdateAsync(Guid ID, PostUpdateVM request)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ChangeVisibilityAsync(Guid IDPost, PostVisibility newVisibility)
        {
            var post = await _dbContext.Post.FindAsync(IDPost);

            if (post == null)
            {
                return false;
            }

            post.PostVisibility = newVisibility;
            post.ModifiedBy = "";
            post.ModifiedDate = DateTime.Now;
            await _dbContext.SaveChangesAsync();

            return true;
        }

    }
}
