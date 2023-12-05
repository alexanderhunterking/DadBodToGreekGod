using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DadBodToGreekGod.Models.Meal;

namespace DadBodToGreekGod.Services.Meal
{
    public interface IMealService
    { 
    Task<MealDetailsModel?> CreateMealAsync(CreateMealModel request);

    Task<MealDetailsModel> GetMealDetailsAsync(int mealId);

    Task<IEnumerable<MealListItemModel>> GetUserMealsAsync();

    Task UpdateMealAsync(int mealId, UpdateMealModel updateModel);

    Task DeleteMealAsync(int mealId);
    }
}