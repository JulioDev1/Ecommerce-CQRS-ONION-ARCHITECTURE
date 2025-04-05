using DigitalProducts.Application.Queries.User.GetUserByEmail;
using DigitalProducts.Infra.Repositories.Interfaces;
using DigitalProducts.Shared.Dtos;
using MediatR;

namespace DigitalProducts.Application.Commands.Product.CreateProductHandler
{
    public class CreateProductHandler : IRequestHandler<CreateProductRequest, long>
    {
        private readonly IProductRepository productRepository;
        private readonly IMediator mediator;

        public CreateProductHandler(IMediator mediator, IProductRepository productRepository)
        {
            this.mediator = mediator;
            this.productRepository = productRepository;
        }

        public async Task<long> Handle(CreateProductRequest command, CancellationToken cancellationToken) 
        {
            var user = await mediator.Send(new GetUserByEmailRequest(command.Email));

            if (command.VerifyRole(user.Role) is false) 
            {
                throw new UnauthorizedAccessException("just admin can create products");
            }

            var product = new ProductDto(command.Name,
                          command.Price,
                          command.Description,
                          command.CreatorId,
                          command.PathImage,
                          command.TypeProductId
            );

           return await productRepository.CreateProduct(product);
        }
    }
}
