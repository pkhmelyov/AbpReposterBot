using System.ComponentModel.DataAnnotations;

namespace pkhmelyov.AbpReposterBot.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}