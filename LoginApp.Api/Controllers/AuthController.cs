using Microsoft.AspNetCore.Mvc;
using LoginApp.Api.Data;
using LoginApp.Api.Models;
namespace LoginApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserRepository _repo;
        public AuthController(UserRepository repo) => _repo = repo;

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest.UsernamePassword request)
        {
            var user = await _repo.GetByUsernameAsync(request.Username);
            if (user == null) return Unauthorized("User not found");

            if (user.PasswordHash != request.Password)
                return Unauthorized("Invalid username or password.");
            return Ok(new { message = "Login Successful", username = user.Username});
        }
    }
}
