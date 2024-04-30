using DataAccessLayer.Entities.Base;
using static DataAccessLayer.Entities.Base.EnumBase;

namespace DataAccessLayer.Entities
{
    public partial class Information : EntityBase
    {
        public string IDUser { get; set; } = null!;
        public string FirstAndLastName { get; set; } = null!;//Họ và tên
        public DateTime BirthDate { get; set; }//Năm sinh
        public DateTime JoinDate { get; set; }//Ngày tạo tài khoản
        public string? Bio { get; set; }//Giới thiệu
        public double? Height { get; set; }//Chiều cao
        public double? Weight { get; set; }//Cân nặng
        public string? JobTitle { get; set; }//Chức danh
        public string? School { get; set; }//Trường học
        public string? CurrentPlaceOfResidence { get; set; }//Nơi sống hiện tại
        public Gender Gender { get; set; }//Giới tính
        public SexualOrientation SexualOrientation { get; set; }//Xu hướng tình dục
        public DatingPurposes DatingPurposes { get; set; }//Mục đích hẹn hò
        public PersonalPronouns PersonalPronouns { get; set; }//Đại từ
        public Interests Interests { get; set; }//Sở thích
        public Language Language { get; set; }//Ngôn ngữ
        public virtual ApplicationUser ApplicationUser { get; set; } = null!;
    }
}
