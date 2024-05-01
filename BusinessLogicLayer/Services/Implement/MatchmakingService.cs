//using BusinessLogicLayer.Services.Interface;
//using DataAccessLayer.ApplicationDBContext;
//using DataAccessLayer.Entities;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;

//namespace BusinessLogicLayer.Services.Implement
//{
//    public class MatchmakingService 
//    {
//        private readonly SoulMateIdentittyDBContext _dbContext;
//        private readonly UserManager<ApplicationUser> _userManager;

//        public MatchmakingService(SoulMateIdentittyDBContext dbContext, UserManager<ApplicationUser> userManager)
//        {
//            _userManager = userManager;
//            _dbContext = dbContext;
//        }

//        private static double CalculateCompatibilityPercentage(SoulMateIdentittyDBContext dbContext, ApplicationUser user1, ApplicationUser user2)
//        {
//            var user1Attributes = GetUserAttributes(dbContext, user1.Id);
//            var user2Attributes = GetUserAttributes(dbContext, user2.Id);

//            var matchingAttributes = 0;

//            foreach (var attribute in user1Attributes)
//            {
//                if (user2Attributes.TryGetValue(attribute.Key, out var value) && value == attribute.Value)
//                {
//                    matchingAttributes++;
//                }
//            }

//            int totalAttributes = user1Attributes.Count;

//            double compatibilityPercentage = (double)matchingAttributes / totalAttributes * 100;

//            return compatibilityPercentage;
//        }
//        private static int CalculateAge(DateTime birthDate)
//        {
//            var today = DateTime.Today;
//            var age = today.Year - birthDate.Year;
//            if (birthDate.Date > today.AddYears(-age)) age--;
//            return age;
//        }
//        private static Dictionary<string, string> GetUserAttributes(SoulMateIdentittyDBContext dbContext, string IDUser)
//        {
//            var userAttributes = new Dictionary<string, string>();

//            var extraInfo = dbContext.ExtraInformation.AsNoTracking().FirstOrDefault(e => e.IDUser == IDUser);
//            var info = dbContext.Information.AsNoTracking().FirstOrDefault(i => i.IDUser == IDUser);
//            var styleOfLife = dbContext.StyleOfLife.AsNoTracking().FirstOrDefault(sl => sl.IDUser == IDUser);

//            if (extraInfo != null)
//            {
//                userAttributes.Add(nameof(extraInfo.Zodiac), extraInfo.Zodiac.ToString());
//                userAttributes.Add(nameof(extraInfo.AcademicLevel), extraInfo.AcademicLevel.ToString());
//                userAttributes.Add(nameof(extraInfo.PersonalityType), extraInfo.PersonalityType.ToString());
//                userAttributes.Add(nameof(extraInfo.ChildDesire), extraInfo.ChildDesire.ToString());
//                userAttributes.Add(nameof(extraInfo.CommunicationStyle), extraInfo.CommunicationStyle.ToString());
//            }

//            if (info != null)
//            {
//                userAttributes.Add(nameof(info.BirthDate), CalculateAge(info.BirthDate).ToString());
//                userAttributes.Add(nameof(info.Height), info.Height.ToString());
//                userAttributes.Add(nameof(info.Weight), info.Weight.ToString());
//                userAttributes.Add(nameof(info.JobTitle), info.JobTitle);
//                userAttributes.Add(nameof(info.School), info.School);
//                userAttributes.Add(nameof(info.CurrentPlaceOfResidence), info.CurrentPlaceOfResidence);
//                userAttributes.Add(nameof(info.SexualOrientation), info.SexualOrientation.ToString());
//                userAttributes.Add(nameof(info.DatingPurposes), info.DatingPurposes.ToString());
//                userAttributes.Add(nameof(info.Interests), info.Interests.ToString());
//            }

//            if (styleOfLife != null)
//            {
//                userAttributes.Add(nameof(styleOfLife.PetType), styleOfLife.PetType.ToString());
//                userAttributes.Add(nameof(styleOfLife.AlcoholConsumption), styleOfLife.AlcoholConsumption.ToString());
//                userAttributes.Add(nameof(styleOfLife.SmokingHabit), styleOfLife.SmokingHabit.ToString());
//                userAttributes.Add(nameof(styleOfLife.DietHabit), styleOfLife.DietHabit.ToString());
//                userAttributes.Add(nameof(styleOfLife.ExerciseHabit), styleOfLife.ExerciseHabit.ToString());
//                userAttributes.Add(nameof(styleOfLife.SocialMediaActivityLevel), styleOfLife.SocialMediaActivityLevel.ToString());
//                userAttributes.Add(nameof(styleOfLife.SleepHabit), styleOfLife.SleepHabit.ToString());
//            }

//            return userAttributes;
//        }


//        public async Task<List<IMatchViewModel>> FindMatchesAsync(string IDUser)
//        {
//            var user = await _userManager.FindByIdAsync(IDUser);
//            if (user == null)
//            {
//                return new List<IMatchViewModel>();
//            }

//            var matches = await _dbContext.ApplicationUsers
//                            .Where(u => u.Id != IDUser) 
//                            .Select(u => new MatchViewModel
//                            {
//                                IDUser = u.Id,
//                                CompatibilityPercentage = CalculateCompatibilityPercentage(_dbContext, IDUser, u.Id)
//                            })
//                            .ToListAsync();

//            var matchViewModels = matches.Cast<IMatchViewModel>().ToList();

//            return matchViewModels;
//        }
//    }
//}
