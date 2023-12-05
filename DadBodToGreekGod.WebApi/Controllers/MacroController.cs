using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DadBodToGreekGod.Services.Macro;
using DadBodToGreekGod.Models.Macro;
using DadBodToGreekGod.Models.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DadBodToGreekGod.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MacroController : ControllerBase
    {
        private readonly IMacroService _macroService;
        public MacroController(IMacroService macroService)
        {
            _macroService = macroService;
        }

        // [HttpPost]
        // public async Task<IActionResult> CreateMacro([FromBody] MacroCreate request)
        // {
        //     if(!ModelState.IsValid)
        //     {
        //         return BadRequest(ModelState);
        //     }

        //     var response = await _macroService.CreateMacroAsync(request);
        //     if (response is not null)
        //     {
        //         return Ok(response);
        //     }

        //     return BadRequest(new TextResponse("Could not create macro."));
        // }

        [HttpPost]
        public async Task<IActionResult> CreateMacro([FromBody] MacroCreate request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _macroService.CreateMacroAsync(request);

            if (response is not null)
            {
                // MacroEntity created successfully
                return Ok(response);
            }
            else
            {
                // User has already created a MacroEntity, handle accordingly
                return BadRequest(new TextResponse("User has already created a macro."));
            }
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetMacroById()
        {
            var userMacros = await _macroService.GetMacroByIdAsync();
            return Ok(userMacros);
        }

        // [HttpPut]
        // public async Task<IActionResult> UpdateMacroById([FromBody] MacroUpdate request)
        // {
        //     if(!ModelState.IsValid)
        //     {
        //         return BadRequest(ModelState);
        //     }

        //     return await _macroService.UpdateMacroAsync(request)
        //         ? Ok("Macro updated successfully.")
        //         : BadRequest("Macro could not be found.");
        // }

        [HttpPut]
        public async Task<IActionResult> UpdateMacro([FromBody] MacroUpdate request)
        {
            // Access UserId from the authentication token claims
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _macroService.UpdateMacroAsync(request, userId);

            if (response)
            {
                return Ok(new TextResponse("MacroEntity updated successfully."));
            }
            else
            {
                return NotFound(); // or handle unauthorized or MacroEntity not found accordingly
            }
        }

        //!Delete api/Macro/5
        [HttpDelete("{macroId:int}")]
        public async Task<IActionResult> DeleteMacro([FromRoute] int macroId)
        {
            return await _macroService.DeleteMacroAsync(macroId)
                ? Ok($"Macro {macroId} was deleted successfully.")
                : BadRequest($"Macro {macroId} could not be deleted.");
        }

    }
}
