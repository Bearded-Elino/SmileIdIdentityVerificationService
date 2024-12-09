using System.ComponentModel.DataAnnotations;

namespace IdentityVerificationService.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}