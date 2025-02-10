namespace WebAPICodeFirst.DB.DTO
{
    public class UrlQueryParameters
    {
        public int Page {  get; set; }
        public int PageSize { get; set; }
        public string? Search {  get; set; }
    }
}
