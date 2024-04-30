using System.ComponentModel.DataAnnotations;
using static DataAccessLayer.Entities.Base.EnumBase;

namespace BusinessLogicLayer.Viewmodels.User
{
    public class RegisterUser
    {
        public string FirstAndLastName { get; set; } 
        public DateTime BirthDate { get; set; }//Năm sinh

        //-----------------------------------------------//
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        //-----------------------------------------//
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
        public Language Language { get; set; }//Ngôn ngữ//
        //------------------------------------------------//
        public Zodiac Zodiac { get; set; }
        public AcademicLevel AcademicLevel { get; set; }
        public PersonalityType PersonalityType { get; set; }
        public ChildDesire ChildDesire { get; set; }
        public CommunicationStyle CommunicationStyle { get; set; }
        //---------------------------------------------------------//
        public PetType PetType { get; set; }
        public AlcoholConsumption AlcoholConsumption { get; set; }
        public SmokingHabit SmokingHabit { get; set; }
        public DietHabit DietHabit { get; set; }
        public ExerciseHabit ExerciseHabit { get; set; }
        public SocialMediaActivityLevel SocialMediaActivityLevel { get; set; }
        public SleepHabit SleepHabit { get; set; }
        //------------------------------------------------------------//

        public int Status { get; set; }
    }
}
