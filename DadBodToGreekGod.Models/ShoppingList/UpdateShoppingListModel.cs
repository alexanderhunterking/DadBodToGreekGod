using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DadBodToGreekGod.Models.ShoppingList
{
    public class UpdateShoppingListModel
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int CalendarId { get; set; }

        [Required]
        public int IngredientId { get; set; }

        [Required]
        public double Quantity { get; set; }
    }
}