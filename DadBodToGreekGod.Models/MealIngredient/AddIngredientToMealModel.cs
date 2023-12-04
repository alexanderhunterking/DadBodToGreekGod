using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DadBodToGreekGod.Models.MealIngredient
{
    public class AddIngredientToMealModel
    {
         [Required]
    public int MealId { get; set; }

    [Required]
    public int IngredientId { get; set; }

    [Required]
    public double Quantity { get; set; }
    }
}