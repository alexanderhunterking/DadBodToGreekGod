using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DadBodToGreekGod.Data.Entities
{
    public class MealEntity
    {
        [Key]
    public int MealId { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public int CalendarId { get; set; }

    public string MealName { get; set; }

    public string Description { get; set; }

    // Other meal-related information

    [ForeignKey("UserId")]
    public UserEntity User { get; set; }

    [ForeignKey("CalendarId")]
    public CalendarEntity Calendar { get; set; }

    public List<MealIngredientEntity> MealIngredients { get; set; }
    }
}