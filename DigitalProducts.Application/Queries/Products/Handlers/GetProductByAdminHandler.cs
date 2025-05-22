using DigitalProducts.Application.Queries.Products.HandlerQuery;
using DigitalProducts.Application.Queries.User.GetUserByEmail;
using DigitalProducts.Domain.Pagination;
using DigitalProducts.Infra.Repositories.Interfaces;
using DigitalProducts.Shared.Dtos;
using MediatR;

namespace DigitalProducts.Application.Queries.Products.Handlers
{
    public class GetProductByAdminHandler : 
        IRequestHandler<GetProductsByAdminRequest, PagedList<AdminProductsDto>>, 
        IRequestHandler<AllProductsHandlers, PagedList<AllProductsFiltered>>
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

            return await productRepository.SelectAdminProduct(request.AdminId, request.PageNumber, request.PageSize);
        }

        public async Task<PagedList<AllProductsFiltered>> Handle(AllProductsHandlers request, CancellationToken cancellationToken)
        {
            var filterProductDto = new FilterProductDto { 
                maxPrice = request.MaxPrice, 
                minPrice = request.MinPrice, 
                typeProduct = request.TypeProduct 
            };
          
            var pagedProductsFilter = new FilterPagedDto { 
                FilterProductDto= filterProductDto,
                PageNumber= request.PageNumber,
                PageSize= request.PageSize 
            };

            return await productRepository.AllProducts(pagedProductsFilter);
        }
    }
}
