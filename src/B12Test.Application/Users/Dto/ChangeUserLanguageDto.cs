using System.ComponentModel.DataAnnotations;

namespace B12Test.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}