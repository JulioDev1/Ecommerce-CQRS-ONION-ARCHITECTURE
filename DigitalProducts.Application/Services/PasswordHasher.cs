using DigitalProducts.Domain.Services;

namespace DigitalProducts.Application.Services
{
    public class PasswordHasher : IPasswordHasher
    {
        public bool Compare(string password, string comparePassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, comparePassword);
        }

        public string Hasher(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);

        }
    }
}
