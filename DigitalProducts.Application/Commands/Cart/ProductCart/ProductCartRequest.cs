using MediatR;

namespace DigitalProducts.Application.Commands.Cart.ProductCart
{
    public class ProductCartRequest : IRequest<ProductCartResponse>
    {
        public long CartId { get; set; }
        public long ProductId { get; set; }
    }
}
