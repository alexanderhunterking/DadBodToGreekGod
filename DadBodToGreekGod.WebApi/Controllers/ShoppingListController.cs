using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DadBodToGreekGod.Models.ShoppingList;
using DadBodToGreekGod.Services.ShoppingList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DadBodToGreekGod.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/shoppinglists")]
    public class ShoppingListController : ControllerBase
    {
        private readonly IShoppingListService _shoppingListService;

        public ShoppingListController(IShoppingListService shoppingListService)
        {
            _shoppingListService = shoppingListService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateShoppingList([FromBody] CreateShoppingListModel createModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var shoppingListId = await _shoppingListService.CreateShoppingListAsync(createModel);

            return CreatedAtAction(nameof(GetShoppingList), new { userId = createModel.UserId }, null);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetShoppingList(int userId)
        {
            var shoppingList = await _shoppingListService.GetShoppingListAsync(userId);

            return Ok(shoppingList);
        }

        [HttpPut("{shoppingListId}")]
        public async Task<IActionResult> UpdateShoppingListItem(int shoppingListId, [FromBody] UpdateShoppingListModel updateModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _shoppingListService.UpdateShoppingListItemAsync(shoppingListId, updateModel);

            return NoContent();
        }

        [HttpDelete("{shoppingListId}")]
        public async Task<IActionResult> RemoveIngredientFromShoppingList(int shoppingListId)
        {
            await _shoppingListService.RemoveIngredientFromShoppingListAsync(shoppingListId);

            return NoContent();
        }
    }
}