using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DadBodToGreekGod.Data.Entities;

namespace DadBodToGreekGod.Models.Calendar
{
    public class CalendarWeekCreateModel
    {

    [Required]
    public DayOfTheWeek ShoppingDay { get; set; }

    [Required]
    public DayOfTheWeek CookingDay { get; set; }

    }
}