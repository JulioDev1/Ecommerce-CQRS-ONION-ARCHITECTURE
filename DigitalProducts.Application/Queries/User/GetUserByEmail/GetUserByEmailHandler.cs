using DigitalProducts.Application.Exceptions;
using DigitalProducts.Infra.Repositories.Interfaces;
using DigitalProducts.Shared.Dtos;
using MediatR;
using static DigitalProducts.Shared.Dtos.UserDto;

namespace DigitalProducts.Application.Queries.User.GetUserByEmail
{
    public class GetUserByEmailHandler : IRequestHandler<GetUserByEmailRequest, UserTypeDto>
    {
        private readonly IUserRepositories userRepositories;

        public GetUserByEmailHandler(IUserRepositories userRepositories)
        {
            this.userRepositories = userRepositories;
        }
        public async Task<UserTypeDto> Handle(GetUserByEmailRequest request, CancellationToken cancellationToken)
        {
           var userFinded = await userRepositories.FindUserByEmail(request.Email);

            if (userFinded is null) {
                throw new NotFoundException("user not exists");
            }
                       
            return new UserTypeDto(userFinded.Name, userFinded.Email, (RoleUser)userFinded.role);
        }
    }
}
