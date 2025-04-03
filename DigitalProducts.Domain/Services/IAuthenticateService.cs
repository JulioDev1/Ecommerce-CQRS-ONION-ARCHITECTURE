using DigitalProducts.Domain.Models;
using DigitalProducts.Shared.Dtos;

namespace DigitalProducts.Domain.Services
{
    public interface IAuthenticateService
    {
        Task<User?> AuthenticateUser(LoginDto loginDto);
        string GenerateAuthToken(User user);
    }
}
