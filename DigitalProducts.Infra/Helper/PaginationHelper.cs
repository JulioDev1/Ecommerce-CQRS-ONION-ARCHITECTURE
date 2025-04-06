using DigitalProducts.Domain.Pagination;
using Microsoft.EntityFrameworkCore;

namespace DigitalProducts.Infra.Helper
{
    public static class PaginationHelper
    {
        public static async Task<PagedList<T>> CreateAsync<T>(IQueryable<T> items, int pageSize, int pageNumber) where T : class
        {
            var count = await items.CountAsync<T>();

            var item = await items.Skip((pageNumber - 1) * pageSize).Take((pageSize)).ToListAsync();

            return new PagedList<T>(item, pageNumber, pageSize, count);
        }
    }
}
