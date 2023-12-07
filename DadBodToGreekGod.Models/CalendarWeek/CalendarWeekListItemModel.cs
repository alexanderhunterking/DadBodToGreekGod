using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DadBodToGreekGod.Data.Entities;

namespace DadBodToGreekGod.Models.Calendar
{
    public class CalendarWeekListItemModel
    {
    public int CalendarId { get; set; }

    public int UserId { get; set; }

    public DayOfTheWeek ShoppingDay { get; set; }

    public DayOfTheWeek CookingDay { get; set; }

    }
}