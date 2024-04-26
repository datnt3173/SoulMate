namespace DataAccessLayer.Entities.Base
{
    public class EnumBase
    { 
        //Mục đích hẹn hò
        public enum DatingPurposes
        {
            Lover,//Tình yêu
            YouDateLongTerm, //bạn hẹn hò lâu dài
            NoStringsAttachedRelationship,//Không có mối quan hệ ràng buộc
            NewFriends, //Bạn mới
            NotVeryClear, //Chưa rõ lắm
        }
        //Đại từ
        public enum PersonalPronouns
        {
            She,
            He,
            They
        }
        //Ngôn ngữ
        public enum Language
        {
            NONE,
            ENGLISH,
            SPANISH,
            FRENCH,
            GERMAN,
            CHINESE,
            JAPANESE,
            KOREAN,
            ITALIAN,
            PORTUGUESE,
            RUSSIAN,
            ARABIC,
            HINDI,
            BENGALI,
            PUNJABI,
            URDU,
            TURKISH,
            POLISH,
            DUTCH,
            VIETNAMESE,
            THAI,
            INDONESIAN,
            MALAY,
            FILIPINO,
            SWEDISH,
            NORWEGIAN,
            DANISH,
            FINNISH,
            GREEK,
            HUNGARIAN,
            CZECH,
            ROMANIAN,
            UKRAINIAN,
            HEBREW,
            LITHUANIAN,
            LATVIAN,
            ESTONIAN,
            CROATIAN,
            SERBIAN,
            SLOVAK,
            SLOVENIAN,
            BULGARIAN,
            MACEDONIAN,
            ALBANIAN,
            GEORGIAN,
            ARMENIAN,
            KAZAKH,
            UZBEK,
            TAJIK,
            KYRGYZ,
            TURKMEN,
            MONGOLIAN,
            LAO,
            KHMER,
            NEPALI,
            SINHALA,
            DHIVEHI,
            MALTESE,
            ICELANDIC,
            FAROESE,
            GREENLANDIC,
            SAMI,
            KURDISH,
            PASHTO,
            DHATKI,
            SINDHI,
            KASHMIRI,
            LUXEMBOURGISH,
            MANX,
            CORSICAN,
            ALSATIAN,
            YORUBA,
            IGBO,
            HAUSA,
            SWAHILI,
            KINYARWANDA,
            AMHARIC,
            SOMALI,
            TIGRINYA,
            GUARANI,
            CEBUANO,
            WARAY,
            CHAVACANO,
            TETUM
        }
        //Sở thích
        public enum Interests
        {
            NONE,
            SPORTS,//Thể thao
            MUSIC,//Âm nhạc
            TRAVEL,//Du lịch
            READING,//Đọc sách
            COOKING,//Nấu ăn
            PHOTOGRAPHY,//Chụp ảnh
            ART,//Vẽ
            DANCING,//Nhảy
            FITNESS,//Khiêu vũ
            VIDEO_GAMES,//Chơi game
            MOVIES,//Xem phim
            FASHION,//Thời trang
            TECHNOLOGY,//Công nghệ
            FOOD_AND_DRINK,//Đồ ăn
            OUTDOORS,//NGoài trời
            ANIMALS,//Động vật
            WRITING,//Viết
            VOLUNTEERING,//Vui vẻ
            YOGA,
            LANGUAGES//Ngôn ngữ
        }
        //Cung hoàng đạo
        public enum Zodiac
        {
            ARIES,//Bạch Dương
            TAURUS,//Kim ngưu
            GEMINI,//Song tử
            CANCER,//Cự giải
            LEO,//Sư tử
            VIRGO,//xử nữ
            LIBRA,//Thiên bình
            SCORPIO,//Bọ cạp
            SAGITTARIUS,//Nhân mã
            CAPRICORN,//Ma kết
            AQUARIUS,//Bảo bình
            PISCES//Song ngư
        }
        //Bằng cấp
        public enum AcademicLevel
        {
            NONE,
            PRESCHOOL,//Mầm non
            ELEMENTARY_SCHOOL,//Tiểu học
            MIDDLE_SCHOOL,//Trung học
            HIGH_SCHOOL,//Phổ thông
            COLLEGE,//Cao đẳng
            UNIVERSITY,//Đại học
            BACHELOR,//Cử nhân
            MASTER,//Thạc sĩ
            TRADE_SCHOOL,//Trường nghề
            POSTGRADUATE,//Sau đại học
            DOCTORATE//Tiến sĩ,
        }
        //Tính cách
        public enum PersonalityType
        {
            NONE,
            INTJ,
            INTP,
            ENTJ,
            ENTP,
            INFJ,
            INFP,
            ENFJ,
            ENFP,
            ISTJ,
            ISFJ,
            ESTJ,
            ESFJ,
            ISTP,
            ISFP,
            ESTP,
            ESFP
        }
        //Gia đình
        public enum ChildDesire
        {
            WantToHaveChildren,//Muốn có
            DoNotWantToHaveChildren,//Không muốn
            AlreadyHaveChildren,//Đã có
            ConsideringHavingChildren//Cân nhắc
        }
        //Cách tiếp cận
        public enum CommunicationStyle
        {
            NONE,
            Direct, // Gặp trực tiếp
            LikeTexting,//Thích nhắn tin
            LikeToCall,//Thích gọi điện
        }
        //Thú cưng
        public enum PetType
        {
            Dog,
            Cat,
            Bird,
            Fish,
            Rabbit,
            Hamster,
            GuineaPig,
            Reptile,
            Other
        }
        public enum AlcoholConsumption
        {
            YesWithNoConcerns,          // Yes, with no concerns - Có, không quan ngại
            YesWithModeration,          // Yes, with moderation - Có, với sự điều độ
            NoPreferNotTo,              // No, prefer not to - Không, thà không
            NoForPersonalReasons,       // No, for personal reasons - Không, vì lý do cá nhân
            NoDueToHealthConcerns,      // No, due to health concerns - Không, vì lo lắng về sức khỏe
            OtherReasons                // Other reasons - Lý do khác
        }
        //Thói quen hút thuốc
        public enum SmokingHabit
        {
            YesRegularly,               // Yes, regularly - Có, thường xuyên
            YesOccasionally,            // Yes, occasionally - Có, đôi khi
            UsedToButQuit,              // Used to, but quit - Từng, nhưng đã bỏ
            NeverStarted,               // Never started - Không bao giờ bắt đầu
            NoForPersonalReasons,       // No, for personal reasons - Không, vì lý do cá nhân
            NoDueToHealthConcerns,      // No, due to health concerns - Không, vì lo lắng về sức khỏe
            OtherReasons                // Other reasons - Lý do khác
        }
        //Thói quen thể dục
        public enum ExerciseHabit
        {
            Regular,            // Regular exercise - Tập thể dục đều đặn
            Irregular,          // Irregular exercise - Tập thể dục không đều đặn
            None                // No exercise - Không tập thể dục
        }
        //Chế độ ăn uống
        public enum DietHabit
        {
            BalancedDiet,       // Balanced diet - Chế độ ăn uống cân đối
            Vegetarian,         // Vegetarian diet - Chế độ ăn chay
            Vegan,              // Vegan diet - Chế độ ăn thuần chay
            LowCarb,            // Low-carb diet - Chế độ ăn ít carbohydrate
            LowFat,             // Low-fat diet - Chế độ ăn ít chất béo
            Keto,               // Keto diet - Chế độ ăn keto
            Paleo,              // Paleo diet - Chế độ ăn paleo
            GlutenFree,         // Gluten-free diet - Chế độ ăn không chứa gluten
            DairyFree,          // Dairy-free diet - Chế độ ăn không chứa sản phẩm sữa
            Mediterranean,      // Mediterranean diet - Chế độ ăn Địa Trung Hải
            Other               // Other diet - Chế độ ăn khác
        }
        public enum SocialMediaActivityLevel
        {
            VeryActive,             // Very active - Rất tích cực
            Active,                 // Active - Tích cực
            Moderate,               // Moderate - Trung bình
            Low,                    // Low - Thấp
            VeryLow,                // Very low - Rất thấp
            None                    // None - Không
        }
        public enum SleepHabit
        {
            EarlyRiser,         // Early riser - Người dậy sớm
            NightOwl,           // Night owl - Người hoạt động vào ban đêm
            RegularSchedule,    // Regular sleep schedule - Lịch trình ngủ đều đặn
            IrregularSchedule,  // Irregular sleep schedule - Lịch trình ngủ không đều đặn
            LightSleeper,       // Light sleeper - Người dễ bị đánh thức
            HeavySleeper,       // Heavy sleeper - Người dễ ngủ sâu
            Insomniac,          // Insomniac - Người mắc chứng mất ngủ
            Other               // Other sleep habit - Thói quen ngủ khác
        }
        //Giới tính
        public enum Gender
        {
            Male,
            Female,
            Other,
            PreferNotToSay//Không muốn nói
        }
        //Xu hướng tình dục
        public enum SexualOrientation
        {
            Heterosexual,       // Heterosexual - Thuận tính giới tính
            Homosexual,         // Homosexual - Đồng tính giới tính
            Bisexual,           // Bisexual - Song tính giới tính
            Pansexual,          // Pansexual - Tất cả tính dục
            Asexual,            // Asexual - Vô tính dục
            Other               // Other orientation - Hướng tình dục khác
        }
    }
}
