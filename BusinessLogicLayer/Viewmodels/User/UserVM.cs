using DataAccessLayer.Entities;
using static DataAccessLayer.Entities.Base.EnumBase;

namespace BusinessLogicLayer.Viewmodels.User
{
    public class UserVM
    {
        public string ID { get; set; }
        public string ImageLink { get; set; }

        //-----------------------------------------------//
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
        //public string? ConfirmPassword { get; set; }
        //-----------------------------------------//
        //Information
        public Guid IDInformation { get; set; }

        public string FirstAndLastName { get; set; }
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
        public Language Language { get; set; }//Ngôn ngữ//
        //------------------------------------------------//
                                              
        //ExtraInformation
        public Guid IDExtraInformation { get; set; }
        public Zodiac Zodiac { get; set; }
        public AcademicLevel AcademicLevel { get; set; }
        public PersonalityType PersonalityType { get; set; }
        public ChildDesire ChildDesire { get; set; }
        public CommunicationStyle CommunicationStyle { get; set; }
        //---------------------------------------------------------//
        //StyleOfLife
        public Guid IDStyleOfLife { get; set; }

        public PetType PetType { get; set; }
        public AlcoholConsumption AlcoholConsumption { get; set; }
        public SmokingHabit SmokingHabit { get; set; }
        public DietHabit DietHabit { get; set; }
        public ExerciseHabit ExerciseHabit { get; set; }
        public SocialMediaActivityLevel SocialMediaActivityLevel { get; set; }
        public SleepHabit SleepHabit { get; set; }
        //------------------------------------------------------------//
        //Post
        //public Guid? IDPost { get; set; }
        //public string Title { get; set; } = null!;
        //public string Content { get; set; } = null!;
        //------------------------------------------------------------//

        //------------------------------------------------------------//
        //------------------------------------------------------------//
        public bool IsActive { get; set; }
        public int Status { get; set; }
    }
}
