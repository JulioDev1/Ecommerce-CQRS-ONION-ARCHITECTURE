using DigitalProducts.Shared.Dtos;
using MediatR;

namespace DigitalProducts.Application.Queries.User.GetUserByEmail
{
    public class GetUserByEmailRequest: IRequest<UserTypeDto>
    {
        public GetUserByEmailRequest(string email) { 
          Email = email;
        }
        public string Email { get; set; } = string.Empty;   
    }
}
