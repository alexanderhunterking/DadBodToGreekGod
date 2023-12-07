using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DadBodToGreekGod.Data.Entities;
using DadBodToGreekGod.Models.Meal;
using DadBodToGreekGod.Models.UserMealAssignment;

namespace DadBodToGreekGod.Models.Calendar
{
    public class CalendarWeekDetailModel
    {
          public int CalendarId { get; set; }

    public int UserId { get; set; }

    public DayOfTheWeek ShoppingDay { get; set; }

    public DayOfTheWeek CookingDay { get; set; }

    public List<CalendarDayListItemModel> CalendarDays { get; set; }
    }
}