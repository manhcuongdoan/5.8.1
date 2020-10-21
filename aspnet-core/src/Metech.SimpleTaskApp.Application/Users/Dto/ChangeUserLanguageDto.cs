using System.ComponentModel.DataAnnotations;

namespace Metech.SimpleTaskApp.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}