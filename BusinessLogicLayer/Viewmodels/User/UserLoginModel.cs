using System.ComponentModel.DataAnnotations;

namespace BusinessLogicLayer.Viewmodels.User
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "Tài khoản là bắt buộc.")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Mật khẩu là bắt buộc.")]
        public string? PassWord { get; set; }
    }
}
