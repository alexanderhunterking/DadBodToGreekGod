using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DadBodToGreekGod.Models.Ingredient;

namespace DadBodToGreekGod.Services.Ingredient
{
    public interface IIngredientService
{
    Task<int> CreateIngredientAsync(CreateIngredientModel createModel);

    Task<IngredientDetailsModel> GetIngredientDetailsAsync(int ingredientId);

    Task<List<IngredientListItemModel>> GetIngredientsAsync();

    Task UpdateIngredientAsync(int ingredientId, UpdateIngredientModel updateModel);

    Task DeleteIngredientAsync(int ingredientId);
}
}