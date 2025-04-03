using DigitalProducts.Domain.Models;
using DigitalProducts.Infra.Repositories.Interfaces;
using DigitalProducts.Shared.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DigitalProducts.Infra.Repositories
{
    public class UserRepository : IUserRepositories
    {
        private readonly AppDbContext context;

        public UserRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<long> CreateUser(UserDto userDto)
        {
            var user = new User
            {
                Email = userDto.Email,
                Name = userDto.Name,
                Password = userDto.Password,
                role = (User.Role)userDto.Role
            };

            context.Users.Add(user);

            await context.SaveChangesAsync();

            return user.Id;
        }

        public async Task<bool> GetUserByEmail(string email)
        {
            return await context.Users.AnyAsync(x => x.Email == email);
        }
    }
}
