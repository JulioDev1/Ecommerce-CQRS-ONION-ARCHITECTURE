using System.Security.Claims;
using DigitalProducts.Application.Commands.Product.CreateProductHandler;
using DigitalProducts.Application.Exceptions;
using DigitalProducts.Application.Queries.Products.GetProductByAdmin;
using DigitalProducts.Extensions;
using DigitalProducts.Model;
using DigitalProducts.Shared.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DigitalProducts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("create-product")]
        [Authorize]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDto productDto)
        {

            var Id = User.Claims.FirstOrDefault(c=> c.Type == ClaimTypes.NameIdentifier)?.Value;
            var email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            if (Id is null || email is null)
            {
                throw new UnauthorizedException("not logged");
            }

            var command = new CreateProductRequest
            {
                CreatorId = long.Parse(Id),
                Description = productDto.Description,
                Email = email,
                Name = productDto.Name,
                PathImage = productDto.PathImage,
                Price = productDto.Price,
                TypeProductId = productDto.TypeProductId,
            };

            var response = await mediator.Send(command);
            
            return Ok(response);    
        }
        [HttpGet("get-admin-products")]
        public async Task<IActionResult> SelectProductAdmin([FromQuery] PaginationParams request)
        {
            var Id = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var Email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            if (Id is null || Email is null)
            {
                throw new UnauthorizedException("not logged");
            }

            var productParams = new GetProductsByAdminRequest
            {
                adminId = long.Parse(Id),
                Email = Email,
                pageNumber = request.PageNumber,
                pageSize = request.PageSize,
            };

            var response = await mediator.Send(productParams);

            Response.AddPaginationHeader(new PaginationHeader(response.CurrentPage, 
                                                              response.PageSize,
                                                              response.TotalItem,
                                                              response.TotalPages));

            return Ok(response);
        }
    }
}
