using DigitalProducts.Domain.Pagination;
using DigitalProducts.Shared.Dtos;

namespace DigitalProducts.Infra.Repositories.Interfaces
{
    public interface ICartRepository
    {
        Task<long> GetUserCart(long userId);
        Task AddProductToUserCart(long productId, long cartId);
        Task<PagedList<ProductsCartDto>> ProductsUserCart(long userId, int pageNumber, int pageSize);
        Task RemoveProductToCart(long cartId, long productId);
        Task<bool> ProductExistsInCart(long productId, long cartId);
        Task ProductQuantityIncrease(long cartId, long productId);
    }
}
