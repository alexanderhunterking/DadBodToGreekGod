using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DadBodToGreekGod.Data.Entities
{
    public class IngredientEntity
    {
    [Key]
    public int IngredientId { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public double CaloriesPer100g { get; set; }

    [Required]
    public double ProteinPer100g { get; set; }

    [Required]
    public double CarbsPer100g { get; set; }

    [Required]
    public double FatPer100g { get; set; }
    }
}