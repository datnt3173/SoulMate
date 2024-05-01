using System.Linq;
using DataAccessLayer.ApplicationDBContext;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class MatchmakingAlgorithm
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SoulMateIdentittyDBContext _context;

    public MatchmakingAlgorithm(UserManager<ApplicationUser> userManager, SoulMateIdentittyDBContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    public async Task<List<MatchResult>> GetMatchResults(string userId)
    {
        var currentUser = await _userManager.FindByIdAsync(userId);
        if (currentUser == null)
        {
            throw new ArgumentException("Invalid user ID");
        }

        var allUsers = await _userManager.Users
            .Include(u => u.ExtraInformation)
            .Include(u => u.Information)
            .Include(u => u.StyleOfLife)
            .ToListAsync();

        var results = allUsers
            .Where(u => u.Id != userId && u.Information != null && u.Information.Gender != currentUser.Information?.Gender)
            .Select(u => new
            {
                UserId = u.Id,
                ExtraInformation = u.ExtraInformation,
                Information = u.Information,
                StyleOfLife = u.StyleOfLife
            })
            .ToList();


        var matchResults = new List<MatchResult>();
        foreach (var result in results)
        {
            double compatibilityScore = CalculateCompatibilityScore(currentUser, result.ExtraInformation, result.Information, result.StyleOfLife);
            double matchPercentage = compatibilityScore;
            string matchPercentageWithSymbol = $"{matchPercentage:F2}%";
            matchResults.Add(new MatchResult
            {
                IDUser = result.UserId,
                CompatibilityScore = compatibilityScore,
                MatchPercentage = matchPercentageWithSymbol
            });
        }

        matchResults = matchResults.OrderByDescending(r => r.CompatibilityScore).ToList();

        return matchResults;
    }

    private double CalculateCompatibilityScore(ApplicationUser currentUser, ExtraInformation extraInfo, Information info, StyleOfLife styleOfLife)
    {
        double score = 0;
        int numberOfCompatibilityFactors = 0;

        score += CalculateScore(extraInfo?.Zodiac, currentUser.ExtraInformation?.Zodiac);
        numberOfCompatibilityFactors++;
        score += CalculateScore(extraInfo?.AcademicLevel, currentUser.ExtraInformation?.AcademicLevel);
        numberOfCompatibilityFactors++;
        score += CalculateScore(extraInfo?.PersonalityType, currentUser.ExtraInformation?.PersonalityType);
        numberOfCompatibilityFactors++;
        score += CalculateScore(extraInfo?.ChildDesire, currentUser.ExtraInformation?.ChildDesire);
        numberOfCompatibilityFactors++;
        score += CalculateScore(extraInfo?.CommunicationStyle, currentUser.ExtraInformation?.CommunicationStyle);
        numberOfCompatibilityFactors++;

        score += CalculateScore(info?.SexualOrientation, currentUser.Information?.SexualOrientation);
        numberOfCompatibilityFactors++;
        score += CalculateScore(info?.DatingPurposes, currentUser.Information?.DatingPurposes);
        numberOfCompatibilityFactors++;
        score += CalculateScore(info?.PersonalPronouns, currentUser.Information?.PersonalPronouns);
        numberOfCompatibilityFactors++;
        score += CalculateScore(info?.Interests, currentUser.Information?.Interests);
        numberOfCompatibilityFactors++;
        score += CalculateScore(info?.Language, currentUser.Information?.Language);
        numberOfCompatibilityFactors++;

        score += CalculateScore(styleOfLife?.PetType, currentUser.StyleOfLife?.PetType);
        numberOfCompatibilityFactors++;
        score += CalculateScore(styleOfLife?.AlcoholConsumption, currentUser.StyleOfLife?.AlcoholConsumption);
        numberOfCompatibilityFactors++;
        score += CalculateScore(styleOfLife?.SmokingHabit, currentUser.StyleOfLife?.SmokingHabit);
        numberOfCompatibilityFactors++;
        score += CalculateScore(styleOfLife?.DietHabit, currentUser.StyleOfLife?.DietHabit);
        numberOfCompatibilityFactors++;
        score += CalculateScore(styleOfLife?.ExerciseHabit, currentUser.StyleOfLife?.ExerciseHabit);
        numberOfCompatibilityFactors++;
        score += CalculateScore(styleOfLife?.SocialMediaActivityLevel, currentUser.StyleOfLife?.SocialMediaActivityLevel);
        numberOfCompatibilityFactors++;
        score += CalculateScore(styleOfLife?.SleepHabit, currentUser.StyleOfLife?.SleepHabit);
        numberOfCompatibilityFactors++;

        if (numberOfCompatibilityFactors == 0)
        {
            return 0;
        }

        return (score / numberOfCompatibilityFactors) * 100; 
    }

    private double CalculateScore(object value1, object value2)
    {
        return (value1 != null && value2 != null && value1.Equals(value2)) ? 1 : 0;
    }

}

public class MatchResult
{
    public string IDUser { get; set; }
    public double CompatibilityScore { get; set; }
    public string MatchPercentage { get; set; }
}
