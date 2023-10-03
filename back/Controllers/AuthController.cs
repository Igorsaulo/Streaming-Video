using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecomerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        public class LoginModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var token = await _authService.Authenticate(model.Email, model.Password);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }

        [HttpGet("validate")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Register()
        {
            var token = HttpContext.Request.Headers["Authorization"]
                .FirstOrDefault()
                ?.Split(" ")
                .Last();
            return Ok(await _authService.ValidateUser(token));
        }
    }
}
