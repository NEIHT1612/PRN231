using System.Security.Cryptography.X509Certificates;

namespace WebAPICodeFirst.DB.DTO
{
    public class PageResponse<T>
    {
        public List<T> Data { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }

        public PageResponse()
        {
        }
        public PageResponse(List<T> data, int page, int pageSize, int totalPages, int totalItems)
        {
            Data = data;
            Page = page;
            PageSize = pageSize;
            TotalPages = totalPages;
            TotalItems = totalItems;
        }
    }
}
