using DigitalProducts.Application.Exceptions;
using DigitalProducts.Domain.Services;
using DigitalProducts.Infra.Repositories.Interfaces;
using DigitalProducts.Shared.Dtos;
using MediatR;

namespace DigitalProducts.Application.Commands.User.CreateUserHandler
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, long>
    {
        private readonly IUserRepositories userRepository;
        private readonly IPasswordHasher passwordHasher;

        public CreateUserHandler(IUserRepositories userRepository, IPasswordHasher passwordHasher)
        {
            this.userRepository = userRepository;
            this.passwordHasher = passwordHasher;
        }
        public async Task<long> Handle(CreateUserRequest command, CancellationToken cancellationToken)
        {
            var verifyUser = await userRepository.GetUserByEmail(command.Email);

            if (verifyUser is true)
            {
                throw new ValidationException("user already exists");
            }

            command.Password = passwordHasher.Hasher(command.Password);

            var userCreated = new UserDto(command.Name, command.Email, command.Password, command.RoleUser);
            
            var id = await userRepository.CreateUser(userCreated);

            return id;
        }
    }
}
