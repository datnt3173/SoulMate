using AutoMapper;
using BusinessLogicLayer.Services.Interface;
using BusinessLogicLayer.Viewmodels;
using BusinessLogicLayer.Viewmodels.User;
using DataAccessLayer.ApplicationDBContext;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mail;
using System.Net;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
namespace BusinessLogicLayer.Services.Implement
{
    public class UserService : IUserService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly MailSettings _mailSettings;
        private readonly SoulMateIdentittyDBContext _heartConnectIdentityDBContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        public UserService(SoulMateIdentittyDBContext HeartConnectIdentityDBContext,
                          UserManager<ApplicationUser> userManager,
                          IMapper mapper,
                          RoleManager<IdentityRole> roleManager,
                          IOptions<MailSettings> mailSettings,
                           IHttpContextAccessor httpContextAccessor,
                           IConfiguration IConfiguration)
        {
            _heartConnectIdentityDBContext = HeartConnectIdentityDBContext;
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;
            _mailSettings = mailSettings.Value;
            _httpContextAccessor = httpContextAccessor;
            _configuration = IConfiguration;
        }
        public async Task<Response> Login(UserLoginModel model)
        {
            if (model == null || string.IsNullOrWhiteSpace(model.UserName) || string.IsNullOrWhiteSpace(model.PassWord))
            {
                return new Response { IsSuccess = false, StatusCode = 400, Message = "Username and password must be provided." };
            }

            try
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user == null || !(await _userManager.CheckPasswordAsync(user, model.PassWord)))
                {
                    return new Response { IsSuccess = false, StatusCode = 401, Message = "Invalid credentials." };
                }

                // Xóa các token, login và claim cũ của người dùng
                await _userManager.RemoveAuthenticationTokenAsync(user, _configuration["JWT:Issuer"], "JWT");
                var logins = await _userManager.GetLoginsAsync(user);
                foreach (var login in logins)
                {
                    await _userManager.RemoveLoginAsync(user, login.LoginProvider, login.ProviderKey);
                }
                var claims = await _userManager.GetClaimsAsync(user);
                foreach (var claim in claims)
                {
                    await _userManager.RemoveClaimAsync(user, claim);
                }

                // Generate JWT token
                var tokenString = await GenerateJwtToken(user);

                // Save JWT token to AspNetUserTokens table
                await SaveJwtTokenToUserAsync(user, tokenString);

                // Save user login information to AspNetUserLogins table
                await SaveUserLoginAsync(user, "HeartConnect", "HeartConnectProviderKey", "UserDisplayName");

                // Save user claims to AspNetUserClaims table
                var userClaims = new List<Claim>();
                var userRoles = await _userManager.GetRolesAsync(user);
                foreach (var role in userRoles)
                {
                    userClaims.Add(new Claim(ClaimTypes.Role, role));
                }
                await SaveUserClaimsAsync(user, userClaims);

                var roles = await _userManager.GetRolesAsync(user);

                return new Response
                {
                    IsSuccess = true,
                    StatusCode = 200,
                    Message = "Authentication successful.",
                    Token = tokenString,
                    Roles = roles.ToList()
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred in Login: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
                return new Response { IsSuccess = false, StatusCode = 500, Message = "Internal server error." };
            }
        }
        private async Task<string> GenerateJwtToken(ApplicationUser user)
        {
            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var role in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            // Tạo token JWT
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                expires: DateTime.Now.AddMinutes(double.Parse(_configuration["JWT:DurationInMinutes"])),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha512Signature)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private async Task SaveUserLoginAsync(ApplicationUser user, string loginProvider, string providerKey, string displayName)
        {
            var userLoginInfo = new UserLoginInfo(loginProvider, providerKey, displayName);
            await _userManager.AddLoginAsync(user, userLoginInfo);
        }
        private async Task SaveUserClaimsAsync(ApplicationUser user, List<Claim> claims)
        {
            foreach (var claim in claims)
            {
                await _userManager.AddClaimAsync(user, claim);
            }
        }
        private async Task SaveJwtTokenToUserAsync(ApplicationUser user, string token)
        {
            await _userManager.SetAuthenticationTokenAsync(user, _configuration["JWT:Issuer"], "JWT", token);
        }
        private async Task<Response> SendConfirmationEmailAsync(string email, Uri callbackUri)
        {
            try
            {
                MailMessage mail = new MailMessage
                {
                    From = new MailAddress(_mailSettings.Mail, _mailSettings.DisplayName),
                    Subject = "Xác nhận địa chỉ email",
                    Body = $"Vui lòng xác nhận địa chỉ email của bạn bằng cách nhấp vào <a href='{callbackUri}'>đây</a>.",
                    IsBodyHtml = true
                };

                mail.To.Add(new MailAddress(email));

                using (SmtpClient smtp = new SmtpClient(_mailSettings.Host, _mailSettings.Port))
                {
                    smtp.Credentials = new NetworkCredential(_mailSettings.Mail, _mailSettings.Password);
                    smtp.EnableSsl = true;

                    await smtp.SendMailAsync(mail);
                }

                return new Response
                {
                    IsSuccess = true,
                    StatusCode = 200,
                    Message = "Email xác nhận đã được gửi."
                };
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và trả về thông báo lỗi
                return new Response
                {
                    IsSuccess = false,
                    StatusCode = 500,
                    Message = $"Lỗi khi gửi email xác nhận: {ex.Message}"
                };
            }
        }
        public async Task<Response> RegisterAsync(RegisterUser registerUser, string role)
        {
            try
            {
                // Kiểm tra email đã tồn tại
                var existingUser = await _userManager.FindByEmailAsync(registerUser.Email);
                if (existingUser != null)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        StatusCode = 400,
                        Message = "This email is already in use."
                    };
                }

                // Kiểm tra tên đăng nhập đã tồn tại
                existingUser = await _userManager.FindByNameAsync(registerUser.Username);
                if (existingUser != null)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        StatusCode = 400,
                        Message = "This username is already taken."
                    };
                }

                // Kiểm tra mật khẩu khớp với mật khẩu xác nhận
                if (registerUser.Password != registerUser.ConfirmPassword)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        StatusCode = 400,
                        Message = "The password and confirmation password do not match."
                    };
                }

                // Tạo một ApplicationUser mới
                var newUser = new ApplicationUser
                {
                    UserName = registerUser.Username,
                    Email = registerUser.Email,
                    PhoneNumber = registerUser.PhoneNumber,
                    IsActive = true,
                    Status = 1,
                    EmailConfirmed = false
                };

                // Thêm người dùng vào cơ sở dữ liệu
                var result = await _userManager.CreateAsync(newUser, registerUser.Password);
                if (result.Succeeded)
                {
                    // Tạo các đối tượng liên quan và thêm chúng vào DbContext
                    Information information = new Information()
                    {
                        ID = Guid.NewGuid(),
                        IDUser = newUser.Id,
                        FirstAndLastName = registerUser.FirstAndLastName,
                        BirthDate = registerUser.BirthDate,
                        JoinDate = DateTime.Now,
                        Bio = registerUser.Bio,
                        Height = registerUser.Height,
                        Weight = registerUser.Weight,
                        JobTitle = registerUser.JobTitle,
                        School = registerUser.School,
                        CurrentPlaceOfResidence = registerUser.CurrentPlaceOfResidence,
                        Gender = registerUser.Gender,
                        SexualOrientation = registerUser.SexualOrientation,
                        DatingPurposes = registerUser.DatingPurposes,
                        PersonalPronouns = registerUser.PersonalPronouns,
                        Interests = registerUser.Interests,
                        Language = registerUser.Language,
                        CreateDate = DateTime.Now,
                        CreateBy = newUser.Id,
                        Status = 1
                    };
                    _heartConnectIdentityDBContext.Information.Add(information);

                    ExtraInformation extraInformation = new ExtraInformation()
                    {
                        ID = Guid.NewGuid(),
                        IDUser = newUser.Id,
                        Zodiac = registerUser.Zodiac,
                        AcademicLevel = registerUser.AcademicLevel,
                        PersonalityType = registerUser.PersonalityType,
                        ChildDesire = registerUser.ChildDesire,
                        CommunicationStyle = registerUser.CommunicationStyle,
                        CreateDate = DateTime.Now,
                        CreateBy = newUser.Id,
                        Status = 1
                    };
                    _heartConnectIdentityDBContext.ExtraInformation.Add(extraInformation);

                    StyleOfLife styleOfLife = new StyleOfLife()
                    {
                        ID = Guid.NewGuid(),
                        IDUser = newUser.Id,
                        PetType = registerUser.PetType,
                        AlcoholConsumption = registerUser.AlcoholConsumption,
                        SmokingHabit = registerUser.SmokingHabit,
                        DietHabit = registerUser.DietHabit,
                        ExerciseHabit = registerUser.ExerciseHabit,
                        SocialMediaActivityLevel = registerUser.SocialMediaActivityLevel,
                        SleepHabit = registerUser.SleepHabit,
                        CreateDate = DateTime.Now,
                        CreateBy = newUser.Id,
                        Status = 1
                    };
                    _heartConnectIdentityDBContext.StyleOfLife.Add(styleOfLife);

                    // Lưu thay đổi vào cơ sở dữ liệu
                    await _heartConnectIdentityDBContext.SaveChangesAsync();

                    // Kiểm tra và tạo vai trò nếu nó chưa tồn tại
                    if (await _roleManager.RoleExistsAsync(role))
                    {
                        // Thêm người dùng vào vai trò
                        await _userManager.AddToRoleAsync(newUser, role);

                        // Tạo token xác nhận email
                        var emailConfirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);

                        // Lấy host từ HTTP context
                        var host = _httpContextAccessor.HttpContext.Request.Host;

                        // Tạo URL xác nhận email
                        var callbackUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{host}/Account/ConfirmEmail?userId={newUser.Id}&code={emailConfirmationToken}";

                        // Gửi email xác nhận
                        var callbackUri = new Uri(callbackUrl);
                        await SendConfirmationEmailAsync(newUser.Email, callbackUri);

                        return new Response
                        {
                            IsSuccess = true,
                            StatusCode = 201,
                            Message = "Register successfully! Please check your email for confirmation."
                        };
                    }
                    else
                    {
                        return new Response
                        {
                            IsSuccess = false,
                            StatusCode = 404,
                            Message = "This role doesn't exist!"
                        };
                    }
                }
                else
                {
                    return new Response
                    {
                        IsSuccess = false,
                        StatusCode = 500,
                        Message = "Register failed, something went wrong!"
                    };
                }
            }
            catch (Exception ex)
            {
                // Xử lý các ngoại lệ xảy ra khi lưu vào cơ sở dữ liệu
                return new Response
                {
                    IsSuccess = false,
                    StatusCode = 500,
                    Message = "An error occurred while saving the entity changes. See the inner exception for details.",

                };
            }
        }
        public async Task<UserVM> GetInformationByID(string ID)
        {
            var user = await _heartConnectIdentityDBContext.ApplicationUsers
                .Where(u => u.Id == ID)
                .Include(u => u.ExtraInformation)
                .Include(u => u.StyleOfLife)
                .Include(u => u.Information)
                .Include(u => u.ImageData)
                .Include(u => u.Post)
                    .ThenInclude(p => p.Comment)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return null;
            }

            var userVM = new UserVM
            {
                ID = user.Id,
                ImageLink = user.ImageData.Any() ? user.ImageData.First().ImageLink : null,
                IDExtraInformation = user.ExtraInformation.ID,
                IDInformation = user.Information.ID,
                IDStyleOfLife = user.StyleOfLife.ID,
                Username = user.UserName,
                Password = user.PasswordHash,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                //--------------------------------------------------//
                Status = user.Status,
                FirstAndLastName = user.Information.FirstAndLastName,
                BirthDate = user.Information.BirthDate,
                JoinDate = user.Information.JoinDate,
                Bio = user.Information.Bio,
                Height = user.Information.Height,
                Weight = user.Information.Weight,
                JobTitle = user.Information.JobTitle,
                School = user.Information.School,
                CurrentPlaceOfResidence = user.Information.CurrentPlaceOfResidence,
                Gender = user.Information.Gender,
                SexualOrientation = user.Information.SexualOrientation,
                DatingPurposes = user.Information.DatingPurposes,
                PersonalPronouns = user.Information.PersonalPronouns,
                Interests = user.Information.Interests,
                Language = user.Information.Language,
                //------------------------------------------------------------------//
                Zodiac = user.ExtraInformation.Zodiac,
                AcademicLevel = user.ExtraInformation.AcademicLevel,
                PersonalityType = user.ExtraInformation.PersonalityType,
                ChildDesire = user.ExtraInformation.ChildDesire,
                CommunicationStyle = user.ExtraInformation.CommunicationStyle,
                //------------------------------------------------------------------//
                PetType = user.StyleOfLife.PetType,
                AlcoholConsumption = user.StyleOfLife.AlcoholConsumption,
                SmokingHabit = user.StyleOfLife.SmokingHabit,
                DietHabit = user.StyleOfLife.DietHabit,
                ExerciseHabit = user.StyleOfLife.ExerciseHabit,
                SocialMediaActivityLevel = user.StyleOfLife.SocialMediaActivityLevel,
                SleepHabit = user.StyleOfLife.SleepHabit,
            };

            return userVM;
        }
        public async Task<bool> RemoveAsync(string ID, string IDUserDelete)
        {
            using (var transaction = _heartConnectIdentityDBContext.Database.BeginTransaction())
            {
                try
                {
                    var obj = await _heartConnectIdentityDBContext.ApplicationUsers.FirstOrDefaultAsync(c => c.Id == ID);

                    if (obj != null)
                    {
                        obj.IsActive = false;
                        obj.DeleteDate = DateTime.Now;
                        obj.DeleteBy = IDUserDelete;

                        _heartConnectIdentityDBContext.ApplicationUsers.Attach(obj);
                        await _heartConnectIdentityDBContext.SaveChangesAsync();


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
        public async Task<List<UserDataVM>> GetAllInformationAsync()
        {
            var users = await _heartConnectIdentityDBContext.ApplicationUsers
                .Include(u => u.Information) // Include thông tin liên quan
                .Include(u => u.ImageData) // Include dữ liệu hình ảnh liên quan
                .ToListAsync();

            var userDataList = users.Select(u => new UserDataVM
            {
                ID = u.Id,
                ImageLink = u.ImageData.Any() ? u.ImageData.First().ImageLink : null,
                FirstAndLastName = u.Information?.FirstAndLastName,
                BirthDate = u.Information?.BirthDate ?? DateTime.MinValue,
                JoinDate = u.Information.JoinDate,
                Username = u.UserName,
                Email = u.Email,
                ModifieBy = u.ModifieBy,
                ModifieDate = u.ModifieDate,
                DeleteBy = u.DeleteBy,
                DeleteDate = u.DeleteDate,
                PhoneNumber = u.PhoneNumber,
                Status = u.Status
            }).ToList();

            return userDataList;
        }

        public async Task<List<UserDataVM>> GetAllActiveInformationAsync()
        {
            var users = await _heartConnectIdentityDBContext.ApplicationUsers
                .Where(c => c.IsActive == true && c.Status == 1)
                .Include(u => u.Information) // Include thông tin liên quan
                .Include(u => u.ImageData) // Include dữ liệu hình ảnh liên quan
                .ToListAsync();

            var userDataList = users.Select(u => new UserDataVM
            {
                ID = u.Id,
                ImageLink = u.ImageData.Any() ? u.ImageData.First().ImageLink : null,
                FirstAndLastName = u.Information?.FirstAndLastName,
                BirthDate = u.Information?.BirthDate ?? DateTime.MinValue,
                JoinDate = u.Information.JoinDate,
                Username = u.UserName,
                Email = u.Email,
                ModifieBy = u.ModifieBy,
                ModifieDate = u.ModifieDate,
                DeleteBy = u.DeleteBy,
                DeleteDate = u.DeleteDate,
                PhoneNumber = u.PhoneNumber,
                Status = u.Status
            }).ToList();

            return userDataList;
        }
    }
}
