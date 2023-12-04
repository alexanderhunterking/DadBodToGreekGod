using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DadBodToGreekGod.Data;
using DadBodToGreekGod.Data.Entities;
using DadBodToGreekGod.Models.Meal;
using DadBodToGreekGod.Models.MealIngredient;
using Microsoft.EntityFrameworkCore;

namespace DadBodToGreekGod.Services.Meal
{
   public class MealService : IMealService
{
    private readonly ApplicationDbContext _context;

    public MealService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> CreateMealAsync(CreateMealModel createModel)
    {
        var mealEntity = new MealEntity
        {
            UserId = createModel.UserId,
            CalendarId = createModel.CalendarId,
            MealName = createModel.MealName,
            Description = createModel.Description
            // Add other properties as needed
        };

        _context.Meals.Add(mealEntity);
        await _context.SaveChangesAsync();

        return mealEntity.MealId;
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
        CalendarId = mealEntity.CalendarId,
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

    public async Task<List<MealListItemModel>> GetUserMealsAsync(int userId)
    {
        var userMeals = await _context.Meals
            .Where(m => m.UserId == userId)
            .Select(m => new MealListItemModel
            {
                MealId = m.MealId,
                MealName = m.MealName
                // Add other properties as needed
            })
            .ToListAsync();

        return userMeals;
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