using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DadBodToGreekGod.Models.Meal;

namespace DadBodToGreekGod.Services.Meal
{
    public interface IMealService
    {
        Task<int> CreateMealAsync(CreateMealModel createModel);

        Task<MealDetailsModel> GetMealDetailsAsync(int mealId);

        Task<List<MealListItemModel>> GetUserMealsAsync(int userId);

        Task UpdateMealAsync(int mealId, UpdateMealModel updateModel);

        Task DeleteMealAsync(int mealId);
    }
}