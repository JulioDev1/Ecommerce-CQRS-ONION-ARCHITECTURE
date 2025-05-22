using System.Security.Claims;
using DigitalProducts.Application.Commands.Product.CreateProductHandler;
using DigitalProducts.Application.Commands.Product.DeleteProductHandler;
using DigitalProducts.Application.Exceptions;
using DigitalProducts.Application.Queries.Products.GetProductById;
using DigitalProducts.Application.Queries.Products.HandlerQuery;
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

            var Id = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
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
        [HttpGet("get-product-by-id")]
        public async Task<IActionResult> SelectProductById([FromQuery] GetProductDto dto)
        {
            var SelectedProduct = new GetProductRequest
            {
                adminId = dto.adminId,
                productId = dto.productId,
            };

            var response = await mediator.Send(SelectedProduct);

            return Ok(response);
        }


        [HttpDelete("delete-product-by-id")]
        [Authorize]
        public async Task DeleteProduct([FromQuery] long productId)
        {
            var Id = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (Id is null) throw new UnauthorizedException("not logged");

            var deleteProductByAdmin = new DeleteProductRequest
            {

                AdminId = long.Parse(Id),
                ProductId = productId
            };

            await mediator.Send(deleteProductByAdmin);
        }


        [HttpGet("all-product-filter")]
        [Authorize]
        public async Task<IActionResult> AllProductFilter([FromQuery] AllProductsHandlers allProductsHandlers)
        {
            var Id = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (Id is null) throw new UnauthorizedException("not logged");

            var products = new AllProductsHandlers
            {
                MaxPrice = allProductsHandlers.MaxPrice,
                MinPrice = allProductsHandlers.MinPrice,
                TypeProduct = allProductsHandlers.TypeProduct,
                PageSize = allProductsHandlers.PageSize,
                PageNumber = allProductsHandlers.PageNumber
            };

            var response = await mediator.Send(products);

            Response.AddPaginationHeader(new PaginationHeader(
                response.CurrentPage,
                response.PageSize,
                response.TotalItem,
                response.TotalPages
            ));

            return Ok(new { response, response.TotalItem });
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
                AdminId = long.Parse(Id),
                Email = Email,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
            };

            var response = await mediator.Send(productParams);

            Response.AddPaginationHeader(new PaginationHeader(response.CurrentPage,
                                                              response.PageSize,
                                                              response.TotalItem,
                                                              response.TotalPages));

            return Ok(new { response, response.TotalItem });
        }
    }
}
