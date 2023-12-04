using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DadBodToGreekGod.Models.ShoppingList
{
    public class ShoppingListDetailsModel
    {
    public int ShoppingListId { get; set; }

    public int UserId { get; set; }

    public int CalendarId { get; set; }

    public int IngredientId { get; set; }

    public double Quantity { get; set; }
    }
}