using System.ComponentModel.DataAnnotations;

namespace DadBodToGreekGod.Models.User
{
    public class UserRegister
    {
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, MinLength(4)]
        public string UserName { get; set; } = string.Empty;

        [Required, MinLength(4)]
        public string Password { get; set; } = string.Empty;
        [Required]
        public bool HasMadeCalendar { get; set; }

        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}