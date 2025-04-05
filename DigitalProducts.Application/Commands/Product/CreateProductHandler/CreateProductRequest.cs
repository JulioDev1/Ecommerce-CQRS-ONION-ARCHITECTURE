using System.ComponentModel.DataAnnotations;
using DigitalProducts.Shared.Dtos;
using MediatR;

namespace DigitalProducts.Application.Commands.Product.CreateProductHandler
{
    public class CreateProductRequest :IRequest<long>
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;       
        public long CreatorId { get; set; }
        public string PathImage { get; set; } = string.Empty;
        public long TypeProductId { get; set; }
        public bool VerifyRole(UserDto.RoleUser user)
        {
            return user == UserDto.RoleUser.Admin;
        }

    }
}
