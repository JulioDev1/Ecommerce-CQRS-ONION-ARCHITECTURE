using DigitalProducts.Domain.Services;
using DigitalProducts.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace DigitalProducts.Controllers
{
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthenticateService authService;

        public AuthenticateController(IAuthenticateService authService)
        {
            this.authService = authService;
        }

        [HttpPost("/auth")]
        public async Task<ActionResult> CreateUser([FromBody] LoginDto login)
        {
            try
            {
                var authUser = await authService.AuthenticateUser(login);

                var generateToken = authService.GenerateAuthToken(authUser!);

                return Ok(new { token = generateToken});
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An unexpected error occurred.", Details = ex.Message });
            }

        }
    }
}
