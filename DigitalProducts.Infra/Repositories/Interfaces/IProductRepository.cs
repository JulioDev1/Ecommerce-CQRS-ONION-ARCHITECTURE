using System.Runtime.CompilerServices;
using DigitalProducts.Domain.Models;
using DigitalProducts.Shared.Dtos;

namespace DigitalProducts.Infra.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<long> CreateProduct(ProductDto product);
    }
}
