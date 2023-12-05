using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DadBodToGreekGod.Data;
using DadBodToGreekGod.Data.Entities;
using DadBodToGreekGod.Models.Meal;
using DadBodToGreekGod.Models.MealIngredient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DadBodToGreekGod.Services.Meal
{
    public class MealService : IMealService
    {
        private readonly ApplicationDbContext _context;
        private readonly int _userId;

        public MealService(UserManager<UserEntity> userManager,
                            SignInManager<UserEntity> signInManager,
                            ApplicationDbContext context)
        {
           
              var currentUser = signInManager.Context.User;
              var userIdClaim = userManager.GetUserId(currentUser);
              var hasValidId = int.TryParse(userIdClaim, out _userId);

               if (hasValidId == false)
            {
                throw new Exception("Attempted to build MacroService without Id Claim.");
            }

            _context = context;
        }

        public async Task<MealDetailsModel?> CreateMealAsync(CreateMealModel request)
        {
            // Check if the user has already created a meal with the same name
            var existingMeal = await _context.Meals
                .FirstOrDefaultAsync(m => m.UserId == _userId && m.MealName == request.MealName);

            if (existingMeal != null)
            {
               throw new InvalidOperationException("A meal with that name has already been created");
            }

            // Proceed with creating a new MealEntity
            MealEntity mealEntity = new()
            {
                UserId = _userId,
                MealName = request.MealName,
                Description = request.Description
                // Add other properties as needed
            };

            _context.Meals.Add(mealEntity);
            var numberOfChanges = await _context.SaveChangesAsync();

            if (numberOfChanges !=1)
            {
                return null;
            }

            MealDetailsModel response = new()
            {
                MealId = mealEntity.MealId,
                UserId = _userId,
                MealName = mealEntity.MealName,
                Description = mealEntity.Description,
            };

            return response;
        }
        public async Task<MealDetailsModel> GetMealDetailsAsync(int mealId)
        {
            var mealEntity = await _context.Meals
                .Include(m => m.MealIngredients)
                .ThenInclude(mi => mi.Ingredient)  // Include the Ingredient details
                .FirstOrDefaultAsync(m => m.MealId == mealId);

            if (mealEntity == null)
            {
                // Handle not found
                return null;
            }

            var mealDetails = new MealDetailsModel
            {
                MealId = mealEntity.MealId,
                UserId = mealEntity.UserId,
                MealName = mealEntity.MealName,
                Description = mealEntity.Description,
                // Add other properties as needed
                MealIngredients = mealEntity.MealIngredients.Select(mi => new MealIngredientListItemModel
                {
                    MealIngredientId = mi.MealIngredientId,
                    IngredientId = mi.IngredientId,
                    IngredientName = mi.Ingredient.Name,
                    Quantity = mi.Quantity
                    // Add other meal ingredient properties as needed
                }).ToList()
            };

            return mealDetails;
        }

        public async Task<IEnumerable<MealListItemModel>> GetUserMealsAsync()
        {

            List<MealListItemModel> meals = await _context.Meals
                .Where(m => m.UserId == _userId)
                .Select(m => new MealListItemModel
                {
                    MealId = m.MealId,
                    MealName = m.MealName
                    // Add other properties as needed
                })
                .ToListAsync();

            return meals;
        }

        public async Task UpdateMealAsync(int mealId, UpdateMealModel updateModel)
        {
            var mealEntity = await _context.Meals.FindAsync(mealId);

            if (mealEntity == null)
            {
                // Handle not found
                return;
            }

            mealEntity.MealName = updateModel.MealName;
            mealEntity.Description = updateModel.Description;
            // Update other properties as needed

            await _context.SaveChangesAsync();
        }

        public async Task DeleteMealAsync(int mealId)
        {
            var mealEntity = await _context.Meals.FindAsync(mealId);

            if (mealEntity == null)
            {
                // Handle not found
                return;
            }

            _context.Meals.Remove(mealEntity);
            await _context.SaveChangesAsync();
        }
    }
}