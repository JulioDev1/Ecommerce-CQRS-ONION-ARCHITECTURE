﻿using System.Runtime.CompilerServices;
using DigitalProducts.Domain.Models;
using DigitalProducts.Domain.Pagination;
using DigitalProducts.Shared.Dtos;

namespace DigitalProducts.Infra.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<long> CreateProduct(ProductDto product);

        Task<PagedList<AdminProductsDto>> SelectAdminProduct(long adminId, int pageNumber, int pageSize);
    }
}
