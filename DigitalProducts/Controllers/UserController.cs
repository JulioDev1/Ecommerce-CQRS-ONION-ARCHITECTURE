using DigitalProducts.Application.Commands.User.CreateUserHandler;
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
    }
}
