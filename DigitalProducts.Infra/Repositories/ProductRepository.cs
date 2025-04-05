using DigitalProducts.Domain.Models;
using DigitalProducts.Infra.Database;
using DigitalProducts.Infra.Repositories.Interfaces;
using DigitalProducts.Shared.Dtos;

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
    }
}
