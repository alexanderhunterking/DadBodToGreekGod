using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DadBodToGreekGod.Models.Meal;
using DadBodToGreekGod.Models.Responses;
using DadBodToGreekGod.Services.Meal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DadBodToGreekGod.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/meals")]
    public class MealController : ControllerBase
    {
        private readonly IMealService _mealService;

        public MealController(IMealService mealService)
        {
            _mealService = mealService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMeal([FromBody] CreateMealModel request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _mealService.CreateMealAsync(request);
            if (response is not null)
            {
                return Ok(response);
            }

            return BadRequest(new TextResponse("Could not create macro."));
        }

        [HttpGet("{mealId}")]
        public async Task<IActionResult> GetMealDetails(int mealId)
        {
            var mealDetails = await _mealService.GetMealDetailsAsync(mealId);

            if (mealDetails == null)
            {
                return NotFound();
            }

            return Ok(mealDetails);
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetUserMeals()
        {
            var userMeals = await _mealService.GetUserMealsAsync();

            return Ok(userMeals);
        }

        [HttpPut("{mealId}")]
        public async Task<IActionResult> UpdateMeal(int mealId, [FromBody] UpdateMealModel updateModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _mealService.UpdateMealAsync(mealId, updateModel);

            return NoContent();
        }

        [HttpDelete("{mealId}")]
        public async Task<IActionResult> DeleteMeal(int mealId)
        {
            await _mealService.DeleteMealAsync(mealId);

            return NoContent();
        }
    }
}