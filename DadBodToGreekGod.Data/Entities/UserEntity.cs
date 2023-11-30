using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace DadBodToGreekGod.Data.Entities
{
    public class UserEntity : IdentityUser<int>
    {
        [MaxLength(100)]
        public string? FirstName { get; set; }

        [MaxLength(100)]
        public string? LastName { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }
        public List<MacroEntity> Macros { get; set; } = new List<MacroEntity>();
    }
}