using DigitalProducts.Domain.Models;
using DigitalProducts.Infra.Database;
using DigitalProducts.Infra.Repositories.Interfaces;
using DigitalProducts.Shared.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

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
            using var transaction = await context.Database.BeginTransactionAsync();
            try
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

                var cart = new Cart
                {
                    UserId = user.Id,
                    CreateAt = DateTime.UtcNow,

                };

                context.Carts.Add(cart);

                await context.SaveChangesAsync();

                await transaction.CommitAsync(); 
                
                return user.Id;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception(ex.Message);
            }
        }

        public async Task<User?> FindUserByEmail(string email)
        {
            return await context.Users.FirstOrDefaultAsync(e => e.Email == email);
        }

        public async Task<bool> GetUserByEmail(string email)
        {
            return await context.Users.AnyAsync(x => x.Email == email);
        }

    }
}
