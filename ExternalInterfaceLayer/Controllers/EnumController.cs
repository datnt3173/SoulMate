using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExternalInterfaceLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnumController : ControllerBase
    {
        [HttpGet("DatingPurposes")]
        public IActionResult GetDatingPurposes()
        {
            var enumValues = Enum.GetNames(typeof(DataAccessLayer.Entities.Base.EnumBase.DatingPurposes));
            return Ok(enumValues);
        }

        [HttpGet("PersonalPronouns")]
        public IActionResult GetPersonalPronouns()
        {
            var enumValues = Enum.GetNames(typeof(DataAccessLayer.Entities.Base.EnumBase.PersonalPronouns));
            return Ok(enumValues);
        }


        [HttpGet("GetLanguage")]
        public IActionResult GetLanguage()
        {
            var enumValues = Enum.GetNames(typeof(DataAccessLayer.Entities.Base.EnumBase.Language));
            return Ok(enumValues);
        }

        [HttpGet("GetInterests")]
        public IActionResult GetInterests()
        {
            var enumValues = Enum.GetNames(typeof(DataAccessLayer.Entities.Base.EnumBase.Interests));
            return Ok(enumValues);
        }

        [HttpGet("GetZodiac")]
        public IActionResult GetZodiac()
        {
            var enumValues = Enum.GetNames(typeof(DataAccessLayer.Entities.Base.EnumBase.Zodiac));
            return Ok(enumValues);
        }

        [HttpGet("GetAcademicLevel")]
        public IActionResult GetAcademicLevel()
        {
            var enumValues = Enum.GetNames(typeof(DataAccessLayer.Entities.Base.EnumBase.AcademicLevel));
            return Ok(enumValues);
        }

        [HttpGet("GetPersonalityType")]
        public IActionResult GetPersonalityType()
        {
            var enumValues = Enum.GetNames(typeof(DataAccessLayer.Entities.Base.EnumBase.PersonalityType));
            return Ok(enumValues);
        }

        [HttpGet("GetChildDesire")]
        public IActionResult GetChildDesire()
        {
            var enumValues = Enum.GetNames(typeof(DataAccessLayer.Entities.Base.EnumBase.ChildDesire));
            return Ok(enumValues);
        }
        [HttpGet("GetCommunicationStyle")]
        public IActionResult GetCommunicationStyle()
        {
            var enumValues = Enum.GetNames(typeof(DataAccessLayer.Entities.Base.EnumBase.CommunicationStyle));
            return Ok(enumValues);
        }
        [HttpGet("GetPetType")]
        public IActionResult GetPetType()
        {
            var enumValues = Enum.GetNames(typeof(DataAccessLayer.Entities.Base.EnumBase.PetType));
            return Ok(enumValues);
        }
        [HttpGet("GetAlcoholConsumption")]
        public IActionResult GetAlcoholConsumption()
        {
            var enumValues = Enum.GetNames(typeof(DataAccessLayer.Entities.Base.EnumBase.AlcoholConsumption));
            return Ok(enumValues);
        }
        [HttpGet("GetSmokingHabit")]
        public IActionResult GetSmokingHabit()
        {
            var enumValues = Enum.GetNames(typeof(DataAccessLayer.Entities.Base.EnumBase.SmokingHabit));
            return Ok(enumValues);
        }
        [HttpGet("GetExerciseHabit")]
        public IActionResult GetExerciseHabit()
        {
            var enumValues = Enum.GetNames(typeof(DataAccessLayer.Entities.Base.EnumBase.ExerciseHabit));
            return Ok(enumValues);
        }
        [HttpGet("GetDietHabit")]
        public IActionResult GetDietHabit()
        {
            var enumValues = Enum.GetNames(typeof(DataAccessLayer.Entities.Base.EnumBase.DietHabit));
            return Ok(enumValues);
        }
        [HttpGet("GetSocialMediaActivityLevel")]
        public IActionResult GetSocialMediaActivityLevel()
        {
            var enumValues = Enum.GetNames(typeof(DataAccessLayer.Entities.Base.EnumBase.SocialMediaActivityLevel));
            return Ok(enumValues);
        }
        [HttpGet("GetSleepHabit")]
        public IActionResult GetSleepHabit()
        {
            var enumValues = Enum.GetNames(typeof(DataAccessLayer.Entities.Base.EnumBase.SleepHabit));
            return Ok(enumValues);
        }
        [HttpGet("GetGender")]
        public IActionResult GetGender()
        {
            var enumValues = Enum.GetNames(typeof(DataAccessLayer.Entities.Base.EnumBase.Gender));
            return Ok(enumValues);
        }
        [HttpGet("GetSexualOrientation")]
        public IActionResult GetSexualOrientation()
        {
            var enumValues = Enum.GetNames(typeof(DataAccessLayer.Entities.Base.EnumBase.SexualOrientation));
            return Ok(enumValues);
        }
    }
}
