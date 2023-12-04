using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DadBodToGreekGod.Models.Calendar
{
    public class CalendarListItemModel
    {
    public int CalendarId { get; set; }

    public int UserId { get; set; }

    public string ShoppingDay { get; set; }

    public string CookingDay { get; set; }

    }
}