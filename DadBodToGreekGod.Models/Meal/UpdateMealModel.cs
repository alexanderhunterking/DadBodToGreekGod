using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DadBodToGreekGod.Models.Meal
{
    public class UpdateMealModel
    {
    [Required]
    public string MealName { get; set; }

    public string Description { get; set; }
    }
}