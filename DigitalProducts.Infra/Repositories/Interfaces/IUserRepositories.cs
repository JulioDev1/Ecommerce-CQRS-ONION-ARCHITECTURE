using DigitalProducts.Domain.Models;
using DigitalProducts.Shared.Dtos;

namespace DigitalProducts.Infra.Repositories.Interfaces
{
    public interface IUserRepositories
    {
        Task<long> CreateUser(UserDto userDto);
        Task<bool> GetUserByEmail(string email);
        Task<User?> FindUserByEmail(string email);

    }
}
