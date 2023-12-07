using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DadBodToGreekGod.Data.Entities
{
    public class MealIngredientEntity
    {
        [Key]
        public int MealIngredientId { get; set; }
        [Required]
        public int UserId { get; set; }

        [Required]
        public int MealId { get; set; }

        [Required]
        public int IngredientId { get; set; }

        [Required]
        public double Quantity { get; set; }
        [ForeignKey("UserId")]
    public UserEntity User { get; set; }

        [ForeignKey("MealId")]
        public MealEntity Meal { get; set; }

        [ForeignKey("IngredientId")]
        public IngredientEntity Ingredient { get; set; }
    }
}