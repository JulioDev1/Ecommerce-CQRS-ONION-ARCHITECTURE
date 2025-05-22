using System.Security.Claims;
using DigitalProducts.Application.Commands.User.CreateUserHandler;
using DigitalProducts.Application.Exceptions;
using DigitalProducts.Application.Queries.User.GetUserByEmail;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DigitalProducts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest command)
        {
            var response = await mediator.Send(command);
            
            return Ok(response);
        }
        [HttpGet("get-user")]
        public async Task<ActionResult> GetUserByEmail()
        {
            var userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            if (userEmail is null) throw new UnauthorizedException("not logged");
            

            var user = new GetUserByEmailRequest(userEmail);

            var response = await mediator.Send(user);

            return Ok(response);
        }
    }
}
