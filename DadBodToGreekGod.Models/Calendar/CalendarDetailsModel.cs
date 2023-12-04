using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DadBodToGreekGod.Data.Entities;
using DadBodToGreekGod.Models.Meal;

namespace DadBodToGreekGod.Models.Calendar
{
    public class CalendarDetailsModel
    {
          public int CalendarId { get; set; }

    public int UserId { get; set; }

    public string ShoppingDay { get; set; }

    public string CookingDay { get; set; }


    public List<MealListItemModel> Meals { get; set; }

    public List<ShoppingListEntity> ShoppingLists { get; set; }
    }
}