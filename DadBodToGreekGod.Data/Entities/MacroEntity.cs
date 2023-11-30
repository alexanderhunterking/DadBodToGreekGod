using System.ComponentModel.DataAnnotations;

namespace DadBodToGreekGod.Data.Entities
{
    public class MacroEntity
    {
        [Key]
        public int Id { get; set; } 

        [Required]
        public int OwnerId { get; set; }
        public UserEntity Owner { get; set; } = null!;

        [Required]
        public int Calories{ get; set; }

        [Required]
        public int Protein{ get; set; }

        [Required]
        public int Carbs{ get; set; }

        [Required]
        public int Fats{ get; set; }
        
        
    }
}