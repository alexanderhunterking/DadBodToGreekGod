using System.ComponentModel.DataAnnotations;

namespace DadBodToGreekGod.Models.Macro
{
    public class MacroUpdate
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        
        public int Calories { get; set; }

        [Required]
        
        public int Protein { get; set; }

        [Required]
        
        public int Carbs { get; set; }

        [Required]
        
        public int Fats { get; set; }
    }
}