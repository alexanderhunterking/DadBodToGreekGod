using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DadBodToGreekGod.Data.Entities;

namespace DadBodToGreekGod.Models.UserMealAssignment
{
    public class CalendarDayCreateModel
    {

        [Required]
        public int MealId { get; set; }

        [Required]
        public MealTime TimeOfDay { get; set; }

        [Required]
        public DayOfTheWeek DayOfTheWeek { get; set; }
    }
}