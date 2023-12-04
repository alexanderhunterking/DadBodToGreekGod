using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DadBodToGreekGod.Models.ShoppingList;

namespace DadBodToGreekGod.Services.ShoppingList
{
    public interface IShoppingListService
    {
        Task<int> CreateShoppingListAsync(CreateShoppingListModel createModel);

        Task<List<ShoppingListItemModel>> GetShoppingListAsync(int userId);

        Task UpdateShoppingListItemAsync(int shoppingListId, UpdateShoppingListModel updateModel);

        Task RemoveIngredientFromShoppingListAsync(int shoppingListId);
    }
}