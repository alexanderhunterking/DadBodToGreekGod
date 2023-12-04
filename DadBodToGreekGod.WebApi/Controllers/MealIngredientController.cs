using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DadBodToGreekGod.Data.Entities;
using Microsoft.EntityFrameworkCore;
using DadBodToGreekGod.Models.MealIngredient;
using DadBodToGreekGod.Services.MealIngredient;
using DadBodToGreekGod.Data;

namespace DadBodToGreekGod.WebApi.Controllers
{
    public class MealIngredientService : IMealIngredientService
    {
        private readonly ApplicationDbContext _context;

        public MealIngredientService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddIngredientToMealAsync(AddIngredientToMealModel addModel)
        {
            var mealIngredientEntity = new MealIngredientEntity
            {
                MealId = addModel.MealId,
                IngredientId = addModel.IngredientId,
                Quantity = addModel.Quantity
                // Add other properties as needed
            };

            _context.MealIngredients.Add(mealIngredientEntity);
            await _context.SaveChangesAsync();

            return mealIngredientEntity.MealIngredientId;
        }

        public async Task<List<MealIngredientListItemModel>> GetMealIngredientsAsync(int mealId)
        {
            var mealIngredients = await _context.MealIngredients
                .Include(mi => mi.Ingredient)
                .Where(mi => mi.MealId == mealId)
                .Select(mi => new MealIngredientListItemModel
                {
                    MealIngredientId = mi.MealIngredientId,
                    IngredientId = mi.IngredientId,
                    IngredientName = mi.Ingredient.Name,
                    Quantity = mi.Quantity
                    // Add other properties as needed
                })
                .ToListAsync();

            return mealIngredients;
        }

        public async Task UpdateMealIngredientAsync(int mealIngredientId, UpdateMealIngredientModel updateModel)
        {
            var mealIngredientEntity = await _context.MealIngredients.FindAsync(mealIngredientId);

            if (mealIngredientEntity == null)
            {
                // Handle not found
                return;
            }

            mealIngredientEntity.Quantity = updateModel.Quantity;
            // Update other properties as needed

            await _context.SaveChangesAsync();
        }

        public async Task RemoveIngredientFromMealAsync(int mealIngredientId)
        {
            var mealIngredientEntity = await _context.MealIngredients.FindAsync(mealIngredientId);

            if (mealIngredientEntity == null)
            {
                // Handle not found
                return;
            }

            _context.MealIngredients.Remove(mealIngredientEntity);
            await _context.SaveChangesAsync();
        }
    }
}