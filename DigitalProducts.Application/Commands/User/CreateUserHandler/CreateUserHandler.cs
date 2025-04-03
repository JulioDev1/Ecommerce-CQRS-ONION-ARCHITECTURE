using DigitalProducts.Application.Exceptions;
using DigitalProducts.Infra.Repositories.Interfaces;
using DigitalProducts.Shared.Dtos;
using MediatR;

namespace DigitalProducts.Application.Commands.User.CreateUserHandler
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, long>
    {
        private readonly IUserRepositories userRepository;

        public CreateUserHandler(IUserRepositories userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<long> Handle(CreateUserRequest command, CancellationToken cancellationToken)
        {
            var verifyUser = await userRepository.GetUserByEmail(command.Email);

            if (verifyUser is true)
            {
                throw new ValidationException("user already exists");
            }

            var userCreated = new UserDto(command.Name, command.Email, command.Password, command.RoleUser);

            var id = await userRepository.CreateUser(userCreated);

            return id;
        }
    }
}
