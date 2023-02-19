using ECommercedb.Models;

namespace ECommercedb
{
    public class ItemResponse<T> where T : class
    {
        public int TotalCount { get; set; }

        public int CurrentPageNumber { get; set; }

        public int PageSize { get; set; }

        public int TotalPages { get; set; }

        public bool HasNextPage { get; set; }

        public bool HasPreviousPage { get; set; }

        public T Data { get; set; }

        public ItemResponse(int totalCount,T data, int currentPageNumber, int pageSize)
        {
            TotalCount = totalCount;
            Data = data;
            CurrentPageNumber = currentPageNumber;
            PageSize = pageSize;

            TotalPages = (int)Math.Ceiling((double)TotalPages / (double)PageSize);

            HasPreviousPage = CurrentPageNumber > 1;
            HasNextPage = CurrentPageNumber < TotalPages;
        }
    }
}
