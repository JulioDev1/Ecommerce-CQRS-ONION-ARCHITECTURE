using DigitalProducts.Domain.Pagination;
using DigitalProducts.Shared.Dtos;
using MediatR;

namespace DigitalProducts.Application.Queries.Products.GetProductByAdmin
{
    public class GetProductsByAdminRequest : IRequest<PagedList<AdminProductsDto>>
    {
        public long adminId { get; set; }
        public int pageNumber { get; set; } 
        public int pageSize { get; set; }
        public string Email { get; set; }
        public bool VerifyRole(UserDto.RoleUser user)
        {
            return user == UserDto.RoleUser.Admin;
        }
    }
}
