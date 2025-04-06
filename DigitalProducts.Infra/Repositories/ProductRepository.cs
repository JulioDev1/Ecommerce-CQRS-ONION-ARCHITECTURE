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
            };

            context.Products.Add(newProduct);

            await context.SaveChangesAsync();
            
            return newProduct.Id;
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
                               product.Product.Name,
                               product.Product.Price,
                               product.Product.Description,
                               product.Product.CreatorId,
                               product.TypeProduct.productType

                    )
                ).AsQueryable();

            return await PaginationHelper.CreateAsync(query, pageSize,pageNumber);
        }
    }
}
