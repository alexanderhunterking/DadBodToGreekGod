using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DadBodToGreekGod.Data.Entities
{
    public class CalendarEntity
    {
         [Key]
    public int CalendarId { get; set; }

    [Required]
    public int UserId { get; set; }

    public string ShoppingDay { get; set; }

    public string CookingDay { get; set; }

    [ForeignKey("UserId")]
    public UserEntity User { get; set; }

    public List<MealEntity> Meals { get; set; }

    public List<ShoppingListEntity> ShoppingLists { get; set; }
    }
}