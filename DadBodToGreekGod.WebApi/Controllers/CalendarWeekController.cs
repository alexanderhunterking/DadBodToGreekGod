using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DadBodToGreekGod.Models.Calendar;
using DadBodToGreekGod.Services.Calendar;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using DadBodToGreekGod.Models.Responses;

namespace DadBodToGreekGod.WebApi.Controllers
{
    [Authorize]
    [ApiController]
[Route("api/[controller]")]
public class CalendarWeekController : ControllerBase
{
    private readonly ICalendarWeekService _calendarWeekService;

    public CalendarWeekController(ICalendarWeekService calendarWeekService)
    {
        _calendarWeekService = calendarWeekService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCalendarWeekDetails()
    {
        var calendarWeekDetails = await _calendarWeekService.GetCalendarWeekDetailsAsync();

        if (calendarWeekDetails == null)
        {
            return NotFound(); // Or handle not found in a way that suits your application
        }

        return Ok(calendarWeekDetails);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCalendarWeek([FromBody] CalendarWeekCreateModel createModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var response = await _calendarWeekService.CreateCalendarWeekAsync(createModel);

        if (response is not null)
        {
            return Ok(response);
        }
        else
        {
            return BadRequest(new TextResponse("User has already created a macro"));
        }

        
    }


    [HttpPut]
    public async Task<IActionResult> UpdateCalendarWeek([FromBody] CalendarWeekUpdateModel updateModel)
    {
        int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
        var response = await _calendarWeekService.UpdateCalendarWeekAsync(updateModel, userId);

            if (response)
            {
                return Ok(new TextResponse("CalendarEntity updated successfully."));
            }
            else
            {
                return NotFound(); // or handle unauthorized or MacroEntity not found accordingly
            }
    }

    [HttpDelete("{calendarId}")]
    public async Task<IActionResult> DeleteCalendarWeek(int calendarId)
    {
        await _calendarWeekService.DeleteCalendarWeekAsync(calendarId);

        return NoContent();
    }
}

}