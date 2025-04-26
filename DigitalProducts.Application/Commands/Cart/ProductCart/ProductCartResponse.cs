using MediatR;

namespace DigitalProducts.Application.Commands.Cart.ProductCart
{
    public class ProductCartResponse : IRequest<ProductCartRequest>
    {
        public ProductCartResponse(long cartId, long productId)
        {
            CartId = cartId;
            ProductId = productId;
        }

        public long CartId { get; set; }
        public long ProductId { get; set; }
    }
}
