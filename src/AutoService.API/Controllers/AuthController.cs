using AutoService.Application.UseCases.AuthServices;
using AutoService.Domain.Entities.DTOs;
using AutoService.Domain.Entities.Models.UserModels;
using AutoService.Domain.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace Clinic.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IAuthService _authService;

        public AuthController(UserManager<User> userManager, IAuthService authService)
        {
            _userManager = userManager;
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegistorDTO register)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResponceModel()
                {
                    IsSuccess = false,
                    Message = "Invalid model state",
                    StatusCode = 400
                });
            }

            var user = new User()
            {
                UserName = register.Firstname,
                Email = register.Email,
                FirstName = register.Firstname,
                LastName = register.Lastname,
                Role = "User"
            };

            var result = await _userManager.CreateAsync(user, register.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(new ResponceModel()
                {
                    IsSuccess = false,
                    Message = "Failed to create user",
                    StatusCode = 400,

                });
            }

            await _userManager.AddToRoleAsync(user, "User");

            return Ok(new ResponceModel()
            {
                IsSuccess = true,
                Message = "User created successfully",
                StatusCode = 201
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new TokenDTO()
                {
                    Message = "Invalid model state",
                    isSuccess = false,
                    Token = ""
                });
            }
            var user = await _userManager.FindByEmailAsync(login.Email);

            if (user == null)
            {
                return BadRequest(new TokenDTO()
                {
                    Message = "Email not found",
                    isSuccess = false,
                    Token = ""
                });
            }

            var checker = await _userManager.CheckPasswordAsync(user, login.Password);
            if (!checker)
            {
                return BadRequest(new TokenDTO()
                {
                    Message = "Incorrect password",
                    isSuccess = false,
                    Token = ""
                });
            }

            var token = _authService.GenerateToken(user);

            return Ok(new TokenDTO()
            {
                Token = token,
                isSuccess = true,
                Message = $"Login successful You id {user.Id}"
            }) ;
        }

    }
}
