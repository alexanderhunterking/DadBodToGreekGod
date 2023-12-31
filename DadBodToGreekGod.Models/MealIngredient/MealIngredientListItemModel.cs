using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DadBodToGreekGod.Models.MealIngredient
{
    public class MealIngredientListItemModel
    {
        public int MealIngredientId { get; set; }

        public int MealId { get; set; }

        public int IngredientId { get; set; }

        public string IngredientName { get; set; }

        public double Quantity { get; set; }

    }
}