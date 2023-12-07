using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DadBodToGreekGod.Models.MealIngredient
{
    public class MealIngredientDetailsModel
    {
        public int MealIngredientId { get; set; }

        public int MealId { get; set; }
        public int UserId { get; set; }

        public int IngredientId { get; set; }

        public double Quantity { get; set; }
    }
}