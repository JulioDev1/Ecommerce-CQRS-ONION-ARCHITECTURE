using DigitalProducts.Domain.Models;
using DigitalProducts.Domain.Pagination;
using DigitalProducts.Infra.Database;
using DigitalProducts.Infra.Helper;
using DigitalProducts.Infra.Repositories.Interfaces;
using DigitalProducts.Shared.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DigitalProducts.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext context;

        public ProductRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<long> CreateProduct(ProductDto product)
        {
            var newProduct = new Product
            {
                Description = product.Description,
                Name = product.Name,
                PathImage = product.PathImage,
                Price = product.Price,
                CreatorId = product.CreatorId,
                TypeProductId = product.TypeProductId,
                Quantity = product.Quantity,
            };

            context.Products.Add(newProduct);

            await context.SaveChangesAsync();

            return newProduct.Id;
        }

        public async Task DeleteProductAdminById(GetProductDto get)
        {
            context.Products.Where(p => p.Id == get.productId && p.CreatorId == get.adminId).ExecuteDelete();
            await context.SaveChangesAsync();
        }

        public async Task<AdminProductsDto?> GetProductsById(GetProductDto get)
        {
            return await context.Products.Join(
                        context.TypeProducts,
                        products => products.TypeProductId,
                        typeProduct => typeProduct.Id,
                        (products, typeProduct) => new { Product = products, TypeProduct = typeProduct }

            ).Where(tp => tp.Product.Id == get.productId && tp.Product.CreatorId == get.adminId)
            .Select(product => new AdminProductsDto(
                   product.Product.Id,
                   product.Product.Quantity,
                   product.Product.Name,
                   product.Product.Price,
                   product.Product.Description,
                   product.Product.CreatorId,
                   product.TypeProduct.productType,
                   product.Product.CreatedAt.ToString("dd/mm/yyyy")
            )).FirstOrDefaultAsync();
        }

        public async Task<PagedList<AdminProductsDto>> SelectAdminProduct(long adminId, int pageNumber, int pageSize)
        {
            var query = context.Products
                .Join(
                    context.TypeProducts,
                    products => products.TypeProductId,
                    typeProduct => typeProduct.Id,
                    (products, typeProduct) => new { Product = products, TypeProduct = typeProduct }

                ).Where(tp => tp.Product.CreatorId == adminId)
                .Select(
                    product => new AdminProductsDto(
                        product.Product.Id,
                        product.Product.Quantity,
                        product.Product.Name,
                        product.Product.Price,
                        product.Product.Description,
                        product.Product.CreatorId,
                        product.TypeProduct.productType,
                        product.Product.CreatedAt.ToString("dd/mm/yyyy")

                    )
                ).AsQueryable();

            return await PaginationHelper.CreateAsync(query, pageSize, pageNumber);
        }

    }
}
