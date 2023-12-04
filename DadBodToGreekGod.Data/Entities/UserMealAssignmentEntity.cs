using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DadBodToGreekGod.Data.Entities
{
    public class UserMealAssignmentEntity
{
    [Key]
    public int UserMealAssignmentId { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public int MealId { get; set; }

    [Required]
    public MealTime TimeOfDay { get; set; }

    [ForeignKey("UserId")]
    public UserEntity User { get; set; }

    [ForeignKey("MealId")]
    public MealEntity Meal { get; set; }
}

public enum MealTime
{
    Breakfast,
    Lunch,
    Dinner,
    Snack
}
}