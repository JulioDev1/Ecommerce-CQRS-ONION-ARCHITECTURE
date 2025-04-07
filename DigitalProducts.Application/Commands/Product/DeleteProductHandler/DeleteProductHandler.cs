using DigitalProducts.Infra.Repositories.Interfaces;
using DigitalProducts.Shared.Dtos;
using MediatR;

namespace DigitalProducts.Application.Commands.Product.DeleteProductHandler
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductRequest, Unit>
    {
        private readonly IProductRepository productRepository;

        public DeleteProductHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public async Task<Unit> Handle(DeleteProductRequest request, CancellationToken cancellationToken) 
        {
            var getIds = new GetProductDto
            {
                adminId = request.AdminId,
                productId = request.ProductId,  

            };

            await productRepository.DeleteProductAdminById(getIds);
            return Unit.Value;
        }
    }
}
