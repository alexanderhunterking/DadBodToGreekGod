using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DadBodToGreekGod.Models.MealIngredient;

namespace DadBodToGreekGod.Models.Meal
{
    public class MealDetailsModel
    {
     public int MealId { get; set; }

    public int UserId { get; set; }

    public string MealName { get; set; }

    public string Description { get; set; }
        // Add the MealIngredients property
    public List<MealIngredientListItemModel> MealIngredients { get; set; }
    }
}