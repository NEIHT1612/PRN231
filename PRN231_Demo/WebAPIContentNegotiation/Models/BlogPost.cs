namespace WebAPIContentNegotiation.Models
{
    public class BlogPost
    {
        public int BlogPostId { get; set; }
        public string Title { get; set; }
        public string MetaDescription { get; set; }
        public bool IsPublished { get; set; }
    }
}
