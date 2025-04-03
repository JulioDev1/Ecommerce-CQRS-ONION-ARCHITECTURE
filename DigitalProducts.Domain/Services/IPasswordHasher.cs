namespace DigitalProducts.Domain.Services
{
    public interface IPasswordHasher
    {
        string Hasher(string password);
        bool Compare(string password, string comparePassword);
    }
}
