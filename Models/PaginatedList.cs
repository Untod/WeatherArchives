using Microsoft.EntityFrameworkCore;

namespace TestTask_DynamicSun.Models
{
    public class PaginatedList<T> : List<T>
    {
        public int PageSize { get; private set; }
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public bool HasNextPage => CurrentPage < TotalPages;
        public bool HasPreviousPage => CurrentPage > 1;

        private PaginatedList(List<T> items, int pageSize, int totalPages, int currentPage)
        {
            PageSize = pageSize;
            TotalPages = totalPages;
            CurrentPage = currentPage;
            AddRange(items);
        }

        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageSize, int currentPage = 1)
        {
            var totalItems = await source.CountAsync();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
            if (currentPage > totalPages)
                currentPage = totalPages;
            if (currentPage < 1)
                currentPage = 1;

            var items = await source.Skip(pageSize * (currentPage - 1)).Take(pageSize).ToListAsync();
            return new PaginatedList<T>(items, pageSize, totalPages, currentPage);
        }
    }
}
