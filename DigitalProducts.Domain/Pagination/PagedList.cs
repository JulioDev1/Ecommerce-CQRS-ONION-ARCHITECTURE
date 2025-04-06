namespace DigitalProducts.Domain.Pagination
{
    public class PagedList<T> : List<T>
    {
        public PagedList(IEnumerable<T> items,int currentPage, int pageSize, int totalItem)
        {
            CurrentPage = currentPage;
            TotalPages = (int) Math.Ceiling(totalItem / (double) pageSize);
            PageSize = pageSize;
            TotalItem = totalItem;
            AddRange(items);
        }

        public PagedList(IEnumerable<T> items, int currentPage, int totalPages, int pageSize, int totalItem)
        {
            CurrentPage = currentPage;
            TotalPages = totalPages;
            PageSize = pageSize;
            TotalItem = totalItem;
            AddRange(items);
        }

        public int CurrentPage { get; set; } // current page
        public int TotalPages { get; set; } // total pages
        public int PageSize { get; set; } // total items per page
        public int TotalItem { get; set; } /// total items per consult

    }
}
