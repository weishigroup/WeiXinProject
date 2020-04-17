using System.ComponentModel.DataAnnotations;

namespace WeiXinProject.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}