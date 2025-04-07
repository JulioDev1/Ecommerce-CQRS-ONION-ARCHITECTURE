using DigitalProducts.Application.Queries.User.GetUserByEmail;
using DigitalProducts.Domain.Pagination;
using DigitalProducts.Infra.Repositories.Interfaces;
using DigitalProducts.Shared.Dtos;
using MediatR;

namespace DigitalProducts.Application.Queries.Products.GetProductByAdmin
{
    public class GetProductByAdminHandler : IRequestHandler<GetProductsByAdminRequest, PagedList<AdminProductsDto>>
    {
        private readonly IProductRepository productRepository;
        private readonly IMediator mediator;

        public GetProductByAdminHandler(IProductRepository productRepository, IMediator mediator)
        {
            this.productRepository = productRepository;
            this.mediator = mediator;
        }

        public async Task<PagedList<AdminProductsDto>> Handle(GetProductsByAdminRequest request, CancellationToken cancellationToken)
        {
            var user = await mediator.Send(new GetUserByEmailRequest(request.Email));

            if (request.VerifyRole(user.Role) is false)
            {
                throw new UnauthorizedAccessException("just admin can create products");
            }

            return await productRepository.SelectAdminProduct(request.adminId, request.pageNumber, request.pageSize);
        }
    }
}
