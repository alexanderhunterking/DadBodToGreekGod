using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DadBodToGreekGod.Models.Calendar
{
    public class CreateCalendarModel
    {
          [Required]
    public int UserId { get; set; }

    public string ShoppingDay { get; set; }

    public string CookingDay { get; set; }

    }
}