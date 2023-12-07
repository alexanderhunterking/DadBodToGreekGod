using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DadBodToGreekGod.Models.MealIngredient;

namespace DadBodToGreekGod.Services.MealIngredient
{
    public interface IMealIngredientService
    {
        Task<MealIngredientDetailsModel> AddIngredientToMealAsync(AddIngredientToMealModel addModel);

        Task<List<MealIngredientListItemModel>> GetMealIngredientsAsync(int mealId);

        Task UpdateMealIngredientAsync(int mealIngredientId, UpdateMealIngredientModel updateModel);

        Task RemoveIngredientFromMealAsync(int mealIngredientId);
    }
}