using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DadBodToGreekGod.Models.Ingredient
{
    public class IngredientDetailsModel
    {
    public int IngredientId { get; set; }

    public string Name { get; set; }

    public double CaloriesPer100g { get; set; }

    public double ProteinPer100g { get; set; }

    public double CarbsPer100g { get; set; }

    public double FatPer100g { get; set; }
    }
}