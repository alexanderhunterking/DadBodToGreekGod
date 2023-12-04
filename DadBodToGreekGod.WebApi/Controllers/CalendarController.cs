using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DadBodToGreekGod.Models.Calendar;
using DadBodToGreekGod.Services.Calendar;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DadBodToGreekGod.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/calendars")]
    public class CalendarController : ControllerBase
    {
        private readonly ICalendarService _calendarService;

        public CalendarController(ICalendarService calendarService)
        {
            _calendarService = calendarService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCalendar([FromBody] CreateCalendarModel createModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var calendarId = await _calendarService.CreateCalendarAsync(createModel);

            return CreatedAtAction(nameof(GetCalendarDetails), new { calendarId }, null);
        }

        [HttpGet("{calendarId}")]
        public async Task<IActionResult> GetCalendarDetails(int calendarId)
        {
            var calendarDetails = await _calendarService.GetCalendarDetailsAsync(calendarId);

            if (calendarDetails == null)
            {
                return NotFound();
            }

            return Ok(calendarDetails);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserCalendars(int userId)
        {
            var userCalendars = await _calendarService.GetUserCalendarsAsync(userId);

            return Ok(userCalendars);
        }

        [HttpPut("{calendarId}")]
        public async Task<IActionResult> UpdateCalendar(int calendarId, [FromBody] UpdateCalendarModel updateModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _calendarService.UpdateCalendarAsync(calendarId, updateModel);

            return NoContent();
        }

        [HttpDelete("{calendarId}")]
        public async Task<IActionResult> DeleteCalendar(int calendarId)
        {
            await _calendarService.DeleteCalendarAsync(calendarId);

            return NoContent();
        }
    }
}