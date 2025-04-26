using DigitalProducts.Application.Exceptions;
using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using DigitalProducts.Application.Commands.Cart.ProductCart;
using Microsoft.AspNetCore.Authorization;

namespace DigitalProducts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IMediator mediator;

        public CartController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("add-product-in-cart")]
        [Authorize]
        public async Task<IActionResult> AddProductInCart(ProductCartRequest productCartRequest)
        {
            var Id = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            if (Id is null || email is null)
            {
                throw new UnauthorizedException("not logged");
            }

            var response =  await mediator.Send(productCartRequest);

            return Ok(response);
        }

    }
}
