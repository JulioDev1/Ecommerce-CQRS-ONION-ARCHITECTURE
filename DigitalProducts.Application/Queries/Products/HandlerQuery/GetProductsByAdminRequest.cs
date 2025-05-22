using DigitalProducts.Domain.Pagination;
using DigitalProducts.Shared.Dtos;
using MediatR;

namespace DigitalProducts.Application.Queries.Products.HandlerQuery
{
    public class GetProductsByAdminRequest : IRequest<PagedList<AdminProductsDto>>
    {
        public long AdminId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Email { get; set; }
        public bool VerifyRole(UserDto.RoleUser user)
        {
            return user == UserDto.RoleUser.Admin;
        }
    }
}
