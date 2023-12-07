using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DadBodToGreekGod.Models.Responses;
using DadBodToGreekGod.Models.UserMealAssignment;
using DadBodToGreekGod.Services.UserMealAssignment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DadBodToGreekGod.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CalendarDayController : ControllerBase
    {
        private readonly ICalendarDayService _calendarDayService;

        public CalendarDayController(ICalendarDayService calendarDayService)
        {
            _calendarDayService = calendarDayService;
        }

        [HttpGet]
        public async Task<ActionResult> GetCalendarDayDetailsAsync()
        {
            var calendarDayDetails = await _calendarDayService.GetCalendarDayDetailsAsync();

            if (calendarDayDetails == null)
            {
                return NotFound();
            }

            return Ok(calendarDayDetails);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCalendarDayAsync([FromBody] CalendarDayCreateModel createModel)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await _calendarDayService.CreateCalendarDayAsync(createModel);
            if (response is not null)
            {
                return Ok(response);
            }

            return BadRequest(new TextResponse("Could not create CalendarDay"));
        }

        [HttpPut("{calendarDayId}")]
        public async Task<ActionResult> UpdateCalendarDayAsync(int calendarDayId, [FromBody] CalendarDayUpdateModel updateModel)
        {
            await _calendarDayService.UpdateCalendarDayAsync(calendarDayId, updateModel);

            return NoContent();
        }

        [HttpDelete("{calendarDayId}")]
        public async Task<ActionResult> DeleteCalendarDayAsync(int calendarDayId)
        {
            await _calendarDayService.DeleteCalendarDayAsync(calendarDayId);

            return NoContent();
        }
    }
}