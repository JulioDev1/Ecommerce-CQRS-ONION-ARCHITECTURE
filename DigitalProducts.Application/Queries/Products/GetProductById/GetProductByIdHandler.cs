using DigitalProducts.Infra.Repositories.Interfaces;
using DigitalProducts.Shared.Dtos;
using MediatR;

namespace DigitalProducts.Application.Queries.Products.GetProductById
{
    public class GetProductByIdHandler : IRequestHandler<GetProductRequest, AdminProductsDto?>
    {
        private readonly IProductRepository productRepository;

        public GetProductByIdHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public async Task<AdminProductsDto?> Handle(GetProductRequest request, CancellationToken cancellationToken)
        {
            var queryProducts = 
                new GetProductDto { 
                    adminId = request.adminId, 
                    productId= request.productId 
                };

            return await productRepository.GetProductsById(queryProducts);
        }
    }
}
