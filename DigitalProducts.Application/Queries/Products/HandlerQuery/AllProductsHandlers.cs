using DigitalProducts.Domain.Pagination;
using DigitalProducts.Shared.Dtos;
using MediatR;

namespace DigitalProducts.Application.Queries.Products.HandlerQuery
{
    public class AllProductsHandlers : IRequest<PagedList<AllProductsFiltered>>
    {
        public decimal? MaxPrice { get; set; }
        public decimal? MinPrice { get; set; }
        public string TypeProduct { get; set; } = string.Empty;
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
