using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DadBodToGreekGod.Models.Ingredient;
using DadBodToGreekGod.Services.Ingredient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DadBodToGreekGod.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/ingredients")]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientService _ingredientService;

        public IngredientController(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateIngredient([FromBody] CreateIngredientModel createModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ingredientId = await _ingredientService.CreateIngredientAsync(createModel);

            return CreatedAtAction(nameof(GetIngredientDetails), new { ingredientId }, null);
        }

        [HttpGet("{ingredientId}")]
        public async Task<IActionResult> GetIngredientDetails(int ingredientId)
        {
            var ingredientDetails = await _ingredientService.GetIngredientDetailsAsync(ingredientId);

            if (ingredientDetails == null)
            {
                return NotFound();
            }

            return Ok(ingredientDetails);
        }

        [HttpGet]
        public async Task<IActionResult> GetIngredients()
        {
            var ingredients = await _ingredientService.GetIngredientsAsync();

            return Ok(ingredients);
        }

        [HttpPut("{ingredientId}")]
        public async Task<IActionResult> UpdateIngredient(int ingredientId, [FromBody] UpdateIngredientModel updateModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _ingredientService.UpdateIngredientAsync(ingredientId, updateModel);

            return NoContent();
        }

        [HttpDelete("{ingredientId}")]
        public async Task<IActionResult> DeleteIngredient(int ingredientId)
        {
            await _ingredientService.DeleteIngredientAsync(ingredientId);

            return NoContent();
        }
    }
}