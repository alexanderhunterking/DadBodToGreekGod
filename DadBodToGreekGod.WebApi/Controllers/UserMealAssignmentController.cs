using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DadBodToGreekGod.Models.UserMealAssignment;
using DadBodToGreekGod.Services.UserMealAssignment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DadBodToGreekGod.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/usermealassignments")]
    public class UserMealAssignmentController : ControllerBase
    {
        private readonly IUserMealAssignmentService _userMealAssignmentService;

        public UserMealAssignmentController(IUserMealAssignmentService userMealAssignmentService)
        {
            _userMealAssignmentService = userMealAssignmentService;
        }

        [HttpPost]
        public async Task<IActionResult> AssignMealToUser([FromBody] AssignMealToUserModel assignModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userMealAssignmentId = await _userMealAssignmentService.AssignMealToUserAsync(assignModel);

            // Return the location of the newly created resource
            return CreatedAtAction(nameof(GetUserMealAssignments), new { userId = assignModel.UserId }, null);
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetUserMealAssignments()
        {
            var userMealAssignments = await _userMealAssignmentService.GetUserMealAssignmentsAsync();

            return Ok(userMealAssignments);
        }

        [HttpPut("{userMealAssignmentId}")]
        public async Task<IActionResult> UpdateUserMealAssignment(int userMealAssignmentId, [FromBody] UpdateUserMealAssignmentModel updateModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _userMealAssignmentService.UpdateUserMealAssignmentAsync(userMealAssignmentId, updateModel);

            return NoContent();
        }

        [HttpDelete("{userMealAssignmentId}")]
        public async Task<IActionResult> RemoveMealFromUser(int userMealAssignmentId)
        {
            await _userMealAssignmentService.RemoveMealFromUserAsync(userMealAssignmentId);

            return NoContent();
        }
    }
}