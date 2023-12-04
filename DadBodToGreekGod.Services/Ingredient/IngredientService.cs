using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DadBodToGreekGod.Data;
using DadBodToGreekGod.Data.Entities;
using DadBodToGreekGod.Models.Ingredient;
using Microsoft.EntityFrameworkCore;

namespace DadBodToGreekGod.Services.Ingredient
{
    public class IngredientService : IIngredientService
{
    private readonly ApplicationDbContext _context;

    public IngredientService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> CreateIngredientAsync(CreateIngredientModel createModel)
    {
        var ingredientEntity = new IngredientEntity
        {
            Name = createModel.Name,
            CaloriesPer100g = createModel.CaloriesPer100g,
            ProteinPer100g = createModel.ProteinPer100g,
            CarbsPer100g = createModel.CarbsPer100g,
            FatPer100g = createModel.FatPer100g
            // Add other properties as needed
        };

        _context.Ingredients.Add(ingredientEntity);
        await _context.SaveChangesAsync();

        return ingredientEntity.IngredientId;
    }

    public async Task<IngredientDetailsModel> GetIngredientDetailsAsync(int ingredientId)
    {
        var ingredientEntity = await _context.Ingredients.FindAsync(ingredientId);

        if (ingredientEntity == null)
        {
            // Handle not found
            return null;
        }

        var ingredientDetails = new IngredientDetailsModel
        {
            IngredientId = ingredientEntity.IngredientId,
            Name = ingredientEntity.Name,
            CaloriesPer100g = ingredientEntity.CaloriesPer100g,
            ProteinPer100g = ingredientEntity.ProteinPer100g,
            CarbsPer100g = ingredientEntity.CarbsPer100g,
            FatPer100g = ingredientEntity.FatPer100g
            // Add other properties as needed
        };

        return ingredientDetails;
    }

    public async Task<List<IngredientListItemModel>> GetIngredientsAsync()
    {
        var ingredients = await _context.Ingredients
            .Select(i => new IngredientListItemModel
            {
                IngredientId = i.IngredientId,
                Name = i.Name
                // Add other properties as needed
            })
            .ToListAsync();

        return ingredients;
    }

    public async Task UpdateIngredientAsync(int ingredientId, UpdateIngredientModel updateModel)
    {
        var ingredientEntity = await _context.Ingredients.FindAsync(ingredientId);

        if (ingredientEntity == null)
        {
            // Handle not found
            return;
        }

        ingredientEntity.Name = updateModel.Name;
        ingredientEntity.CaloriesPer100g = updateModel.CaloriesPer100g;
        ingredientEntity.ProteinPer100g = updateModel.ProteinPer100g;
        ingredientEntity.CarbsPer100g = updateModel.CarbsPer100g;
        ingredientEntity.FatPer100g = updateModel.FatPer100g;
        // Update other properties as needed

        await _context.SaveChangesAsync();
    }

    public async Task DeleteIngredientAsync(int ingredientId)
    {
        var ingredientEntity = await _context.Ingredients.FindAsync(ingredientId);

        if (ingredientEntity == null)
        {
            // Handle not found
            return;
        }

        _context.Ingredients.Remove(ingredientEntity);
        await _context.SaveChangesAsync();
    }
}
}