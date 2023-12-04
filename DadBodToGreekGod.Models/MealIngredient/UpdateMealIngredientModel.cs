using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DadBodToGreekGod.Models.MealIngredient
{
    public class UpdateMealIngredientModel
    {
        [Required]
        public double Quantity { get; set; }
    }
}