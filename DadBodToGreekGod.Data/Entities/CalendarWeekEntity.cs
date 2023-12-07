using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DadBodToGreekGod.Data.Entities
{
    public class CalendarWeekEntity
    {
    [Key]
    public int CalendarId { get; set; }

    [Required]
    public int UserId { get; set; }

    public DayOfTheWeek ShoppingDay { get; set; }

    public DayOfTheWeek CookingDay { get; set; }

    [ForeignKey("UserId")]
    public UserEntity User { get; set; }

    public List<CalendarDayEntity> CalendarDays { get; set; }
    }

    public enum DayOfTheWeek
{
 Sunday,
 Monday,
 Tuesday,
 Wednesday,
 Thursday,
 Friday,
 Saturday,
}
}