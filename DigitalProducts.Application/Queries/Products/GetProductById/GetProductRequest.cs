using DigitalProducts.Shared.Dtos;
using MediatR;

namespace DigitalProducts.Application.Queries.Products.GetProductById
{
    public class GetProductRequest : IRequest<AdminProductsDto>
    {
        public long adminId {  get; set; }
        public long productId { get; set; }
    }
}
