using DigitalProducts.Application.Commands.User.CreateUserHandler;

namespace DigitalProducts.Application.Commands.User.CreateUserHandler.Interface
{
    public interface ICreateUserHandler
    {
        long Handle(CreateUserRequest command);
    }
}
