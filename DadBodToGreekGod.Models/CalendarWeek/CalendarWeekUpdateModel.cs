using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DadBodToGreekGod.Data.Entities;

namespace DadBodToGreekGod.Models.Calendar
{
    public class CalendarWeekUpdateModel
    {
        public DayOfTheWeek ShoppingDay { get; set; }

    public DayOfTheWeek CookingDay { get; set; }
    }
}