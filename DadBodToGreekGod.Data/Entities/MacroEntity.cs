using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DadBodToGreekGod.Data.Entities
{
    public class MacroEntity
    {
        [Key]
        public int Id { get; set; } 

        [Required]
        public int UserId { get; set;}

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