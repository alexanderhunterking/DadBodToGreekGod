using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DadBodToGreekGod.Data.Entities;
using Microsoft.EntityFrameworkCore;
using DadBodToGreekGod.Models.MealIngredient;
using DadBodToGreekGod.Data;
using Microsoft.AspNetCore.Identity;

namespace DadBodToGreekGod.Services.MealIngredient
{
    public class MealIngredientService : IMealIngredientService
{
    private readonly ApplicationDbContext _context;
    private readonly int _userId;

     public MealIngredientService(UserManager<UserEntity> userManager,
                            SignInManager<UserEntity> signInManager,
                            ApplicationDbContext context)
        {
           
              var currentUser = signInManager.Context.User;
              var userIdClaim = userManager.GetUserId(currentUser);
              var hasValidId = int.TryParse(userIdClaim, out _userId);

               if (hasValidId == false)
            {
                throw new Exception("Attempted to build MealService without Id Claim.");
            }

            _context = context;
        }

    public async Task<MealIngredientDetailsModel> AddIngredientToMealAsync(AddIngredientToMealModel addModel)
    {
        // var existingMeal = await _context.MealIngredients
        //         .FirstOrDefaultAsync(m => m.UserId == _userId && m.IngredientId == addModel.IngredientId);

        //     if (existingMeal != null)
        //     {
        //        throw new InvalidOperationException("A meal with that name has already been created");
        //     }

        MealIngredientEntity mealIngredientEntity = new()
        {   
            UserId = _userId,
            MealId = addModel.MealId,
            IngredientId = addModel.IngredientId,
            Quantity = addModel.Quantity
            // Add other properties as needed
        };

        _context.MealIngredients.Add(mealIngredientEntity);
            var numberOfChanges = await _context.SaveChangesAsync();

            if (numberOfChanges !=1)
            {
                return null;
            }

            MealIngredientDetailsModel response = new()
            {
            UserId = _userId,
            MealId = addModel.MealId,
            IngredientId = addModel.IngredientId,
            Quantity = addModel.Quantity
            };

        return response;
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