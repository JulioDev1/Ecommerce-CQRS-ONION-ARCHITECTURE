using DigitalProducts.Shared.Dtos;
using MediatR;

namespace DigitalProducts.Application.Commands.User.CreateUserHandler
{
    public class CreateUserRequest : IRequest<long>
    {

        
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public UserDto.RoleUser RoleUser { get; set; }

    }
}
