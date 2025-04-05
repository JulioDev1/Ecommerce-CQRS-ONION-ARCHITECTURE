using System.Runtime.CompilerServices;
using DigitalProducts.Domain.Models;

namespace DigitalProducts.Infra.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<long> CreateProduct(Product product);
    }
}
