using DigitalProducts.Domain.Models;
using DigitalProducts.Domain.Pagination;
using DigitalProducts.Infra.Database;
using DigitalProducts.Infra.Helper;
using DigitalProducts.Infra.Repositories.Interfaces;
using DigitalProducts.Shared.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DigitalProducts.Infra.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly AppDbContext context;
        public CartRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task AddProductToUserCart(long productId, long cartId)
        {
            var cartProducts = new CartsProduct
            {
                CartId = cartId,
                ProductId = productId,
                Quantity = 1
            };

            context.CartsProducts.Add(cartProducts);

            await context.SaveChangesAsync();
        }

        public async Task<long> GetUserCart(long userId)
        {
            return await context.Carts.
                Where(c => c.UserId == userId)
                .Select(c => c.Id).FirstAsync();
        }

        public async Task ProductQuantityIncrease(long cartId, long productId)
        {
            await context.CartsProducts
                 .Where(cp => cp.CartId == cartId && cp.ProductId == productId)
                 .ExecuteUpdateAsync(p =>
                     p.SetProperty(p=> p.Quantity, p=> p.Quantity + 1));
        }

        public async Task<bool> ProductExistsInCart(long productId, long cartId)
        {
            return await context.CartsProducts.AnyAsync(cp => cp.CartId == cartId && cp.ProductId == productId);
        }

        public async Task<PagedList<ProductsCartDto>> ProductsUserCart(long cartId, int pageNumber, int pageSize)
        {
            var query = context.CartsProducts
                .Where(cp=> cp.CartId == cartId)
                .Join(context.Products,
                    cartProducts => cartProducts.ProductId,
                    product => product.Id,
                    (cartProducts, product) => new {Product = product,CartsProduct = cartProducts}

                ).Select(
                    productCart => new ProductsCartDto(
                        productCart.Product.Name,
                        productCart.Product.Price,
                        productCart.Product.Description,
                        productCart.CartsProduct.Quantity,
                        productCart.CartsProduct.Cart.UserId,
                        productCart.CartsProduct.CartId,
                        productCart.Product.CreatorId,
                        productCart.CartsProduct.ProductId

                    )
                ).AsQueryable();

            return await PaginationHelper.CreateAsync(query, pageSize, pageNumber);
        }

        public async Task RemoveProductToCart(long cartId, long productId)
        {
            context.CartsProducts.Where(cp =>cp.CartId == cartId && cp.ProductId == productId).ExecuteDelete();
            await context.SaveChangesAsync();
        }
    }
}
