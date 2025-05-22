using DigitalProducts.Application.Queries.Cart.ProductCart.QueryHandler;
using DigitalProducts.Domain.Pagination;
using DigitalProducts.Infra.Repositories.Interfaces;
using DigitalProducts.Shared.Dtos;
using MediatR;

namespace DigitalProducts.Application.Queries.Cart.ProductCart
{
    public class ProductUserCartHandler : 
        IRequestHandler<ProductsUserCartRequest, PagedList<ProductsCartDto>>,
        IRequestHandler<GetUserCartRequest,long>

    {
        private readonly ICartRepository cartRepository;

        public ProductUserCartHandler(ICartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }

        public async Task<PagedList<ProductsCartDto>> Handle(ProductsUserCartRequest request, CancellationToken cancellationToken)
        {
            var userCart = await cartRepository.GetUserCart(request.userId);

            var response = await cartRepository.ProductsUserCart(userCart , request.pageNumber, request.pageSize);

            return response;
        }
        public async Task<long> Handle(GetUserCartRequest request, CancellationToken cancellationToken)
        {
            return await cartRepository.GetUserCart(request.userid);
        }
    }
}
