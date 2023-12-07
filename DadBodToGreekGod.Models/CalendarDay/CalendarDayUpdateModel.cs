using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DadBodToGreekGod.Data.Entities;

namespace DadBodToGreekGod.Models.UserMealAssignment
{
    public class CalendarDayUpdateModel
    {

    public int MealId { get; set; }

    public MealTime TimeOfDay { get; set; }

    public DayOfTheWeek DayOfTheWeek { get; set; }
    }
}