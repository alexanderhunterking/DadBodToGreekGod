using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DadBodToGreekGod.Models.User;
using DadBodToGreekGod.Services.User;
using DadBodToGreekGod.Models.Responses;
using DadBodToGreekGod.Models.Token;
using DadBodToGreekGod.Services.Token;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace DadBodToGreekGod.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public UserController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegister model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registerResult = await _userService.RegisterUserAsync(model);
            if(registerResult)
            {
                TextResponse response = new("User was registered.");
                return Ok(response);
            }

            return BadRequest(new TextResponse("User could not be registered."));
        }

        [Authorize]
        [HttpGet("user")]
        public async Task<IActionResult> GetById()
        {
            int id = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var userHasCalendar = await _userService.GetUserByIdAsync(id);

            return Ok(userHasCalendar);
        }

        [Authorize]
        [HttpPut]
         public async Task<IActionResult> UpdateUser([FromBody] UserUpdate request)
        {
            // Access UserId from the authentication token claims
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _userService.UpdateUserAsync(request, userId);

            if (response)
            {
                return Ok(new TextResponse("UserEntity updated successfully."));
            }
            else
            {
                return NotFound(); // or handle unauthorized or UserEntity not found accordingly
            }
        }


        [HttpPost("~/api/Token")]
        public async Task<IActionResult> GetToken([FromBody] TokenRequest request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TokenResponse? response = await _tokenService.GetTokenAsync(request);

            if(response is null)
            {
                return BadRequest(new TextResponse("Invalid Username or Password."));
            }

            return Ok(response);
        }
    }
}
