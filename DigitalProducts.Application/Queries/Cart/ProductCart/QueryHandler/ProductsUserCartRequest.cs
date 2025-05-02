using DigitalProducts.Domain.Pagination;
using DigitalProducts.Shared.Dtos;
using MediatR;

namespace DigitalProducts.Application.Queries.Cart.ProductCart.QueryHandler
{
    public class ProductsUserCartRequest: IRequest<PagedList<ProductsCartDto>>
    {
        public ProductsUserCartRequest(long userId, int pageNumber, int pageSize)
        {
            this.userId = userId;
            this.pageNumber = pageNumber;
            this.pageSize = pageSize;
        }

        public long userId { get; set; }
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
    }
}
