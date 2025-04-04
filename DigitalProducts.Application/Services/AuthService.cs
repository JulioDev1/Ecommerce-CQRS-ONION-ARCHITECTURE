using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DigitalProducts.Application.Services.Helper;
using DigitalProducts.Domain.Models;
using DigitalProducts.Domain.Services;
using DigitalProducts.Infra.Repositories.Interfaces;
using DigitalProducts.Shared.Dtos;
using Microsoft.IdentityModel.Tokens;

namespace DigitalProducts.Application.Services
{
    public class AuthService : IAuthenticateService
    {
        private readonly IUserRepositories userRepositories;
        private readonly IPasswordHasher passwordHasher;
        public AuthService(IUserRepositories userRepositories, IPasswordHasher passwordHasher)
        {
            this.userRepositories = userRepositories;
            this.passwordHasher = passwordHasher;
        }

        public async Task<User?> AuthenticateUser(LoginDto loginDto)
        {
            var userFound = await userRepositories.FindUserByEmail(loginDto.Email);

            if (userFound is null)
            {
                throw new KeyNotFoundException("email not found");
            }
            var comparePassword = passwordHasher.Compare(loginDto.Password, userFound.Password);

            if (!comparePassword)
            {
                throw new UnauthorizedAccessException("incorrectly Password");
            }

            return userFound;
        }

        private static ClaimsIdentity GenerateClaims(User user)
        {
            var claims = new ClaimsIdentity();

            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));

            claims.AddClaim(new Claim(ClaimTypes.Name, user.Email));

            return claims;
        }

        public string GenerateAuthToken(User user)
        {
            var handler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(AuthSetting.PrivateKey);

            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature
            );

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = credentials,
                Expires = DateTime.UtcNow.AddHours(1),
                Subject = GenerateClaims(user)
            };

            var token = handler.CreateToken(tokenDescriptor);

            return handler.WriteToken(token);
        }
    }
}
