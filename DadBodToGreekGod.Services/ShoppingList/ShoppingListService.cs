using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DadBodToGreekGod.Data;
using DadBodToGreekGod.Data.Entities;
using DadBodToGreekGod.Models.ShoppingList;
using Microsoft.EntityFrameworkCore;

namespace DadBodToGreekGod.Services.ShoppingList
{
public class ShoppingListService : IShoppingListService
{
    private readonly ApplicationDbContext _context;

    public ShoppingListService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> CreateShoppingListAsync(CreateShoppingListModel createModel)
    {
        var shoppingListEntity = new ShoppingListEntity
        {
            UserId = createModel.UserId,
            CalendarId = createModel.CalendarId,
            IngredientId = createModel.IngredientId,
            Quantity = createModel.Quantity
            // Add other properties as needed
        };

        _context.ShoppingLists.Add(shoppingListEntity);
        await _context.SaveChangesAsync();

        return shoppingListEntity.ShoppingListId;
    }

    public async Task<List<ShoppingListItemModel>> GetShoppingListAsync(int userId)
    {
        var shoppingList = await _context.ShoppingLists
            .Where(sl => sl.UserId == userId)
            .Select(sl => new ShoppingListItemModel
            {
                ShoppingListId = sl.ShoppingListId,
                UserId = sl.UserId,
                CalendarId = sl.CalendarId,
                IngredientId = sl.IngredientId,
                Quantity = sl.Quantity,
                // Add other properties as needed
            })
            .ToListAsync();

        return shoppingList;
    }

    public async Task UpdateShoppingListItemAsync(int shoppingListId, UpdateShoppingListModel updateModel)
    {
        var shoppingListEntity = await _context.ShoppingLists.FindAsync(shoppingListId);

        if (shoppingListEntity == null)
        {
            // Handle not found
            return;
        }

        shoppingListEntity.Quantity = updateModel.Quantity;
        // Update other properties as needed

        await _context.SaveChangesAsync();
    }

    public async Task RemoveIngredientFromShoppingListAsync(int shoppingListId)
    {
        var shoppingListEntity = await _context.ShoppingLists.FindAsync(shoppingListId);

        if (shoppingListEntity == null)
        {
            // Handle not found
            return;
        }

        _context.ShoppingLists.Remove(shoppingListEntity);
        await _context.SaveChangesAsync();
    }
}
}