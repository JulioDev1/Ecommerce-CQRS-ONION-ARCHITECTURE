using DigitalProducts.Infra.Repositories.Interfaces;
using MediatR;

namespace DigitalProducts.Application.Commands.Cart.ProductCart
{
    public class ProductCartHandler : IRequestHandler<ProductCartRequest, ProductCartResponse>
    {
        private readonly ICartRepository cartRepository;
        public ProductCartHandler(ICartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }

        public async Task<ProductCartResponse> Handle(ProductCartRequest addProductCartRequest, CancellationToken cancellationToken)
        {
            var productInCartExists = await cartRepository.ProductExistsInCart(addProductCartRequest.ProductId, addProductCartRequest.CartId);

            if (productInCartExists is true)
            {
                await cartRepository.ProductQuantityIncrease(addProductCartRequest.CartId, addProductCartRequest.ProductId);

                return new ProductCartResponse(addProductCartRequest.CartId, addProductCartRequest.ProductId);
            }

            await cartRepository.AddProductToUserCart(addProductCartRequest.ProductId, addProductCartRequest.CartId);

            return new ProductCartResponse(addProductCartRequest.CartId, addProductCartRequest.ProductId);
        }
    }
}
