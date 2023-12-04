using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DadBodToGreekGod.Models.MealIngredient;
using DadBodToGreekGod.Services.MealIngredient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DadBodToGreekGod.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/mealingredients")]
    public class MealIngredientController : ControllerBase
    {
        private readonly IMealIngredientService _mealIngredientService;

        public MealIngredientController(IMealIngredientService mealIngredientService)
        {
            _mealIngredientService = mealIngredientService;
        }

        [HttpPost]
        public async Task<IActionResult> AddIngredientToMeal([FromBody] AddIngredientToMealModel addModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mealIngredientId = await _mealIngredientService.AddIngredientToMealAsync(addModel);

            return CreatedAtAction(nameof(MealIngredientDetailsModel), new { mealIngredientId }, null);
        }

        [HttpGet("meal/{mealId}")]
        public async Task<IActionResult> GetMealIngredients(int mealId)
        {
            var mealIngredients = await _mealIngredientService.GetMealIngredientsAsync(mealId);

            return Ok(mealIngredients);
        }

        [HttpPut("{mealIngredientId}")]
        public async Task<IActionResult> UpdateMealIngredient(int mealIngredientId, [FromBody] UpdateMealIngredientModel updateModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _mealIngredientService.UpdateMealIngredientAsync(mealIngredientId, updateModel);

            return NoContent();
        }

        [HttpDelete("{mealIngredientId}")]
        public async Task<IActionResult> RemoveIngredientFromMeal(int mealIngredientId)
        {
            await _mealIngredientService.RemoveIngredientFromMealAsync(mealIngredientId);

            return NoContent();
        }
    }
}