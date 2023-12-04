using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DadBodToGreekGod.Models.Meal
{
    public class CreateMealModel
    {
         [Required]
    public int UserId { get; set; }

    [Required]
    public int CalendarId { get; set; }

    [Required]
    public string MealName { get; set; }

    public string Description { get; set; }
    }
}