using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIContentNegotiation.Models;

namespace WebAPIContentNegotiation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var blogs = new List<Blog>();
            var blogPosts = new List<BlogPost>();

            blogPosts.Add(
                new BlogPost
                {
                    BlogPostId = 1,
                    Title = "Lap trinh C#",
                    MetaDescription = "C# la ngon ngu lap trinh cap cap duoc ua chuong tren toan the gioi",
                    IsPublished = true,
                });
            blogPosts.Add(
                new BlogPost
                {
                    BlogPostId = 2,
                    Title = "Mon hoc PRN231",
                    MetaDescription = "PRN231 la mon hoc chuyen sau ve WEB API",
                    IsPublished = true,
                });
            blogPosts.Add(
                new BlogPost
                {
                    BlogPostId = 3,
                    Title = "Lap trinh PHP",
                    MetaDescription = "PHP la ngon ngu lap trinh web server-side",
                    IsPublished = false,
                });
            blogs.Add(
                new Blog
                {
                    BlogId = 1,
                    BlogName = "Blog ngon ngu lap trinh",
                    BlogDescription = "Blog nay chuyen viet cac bai viet ve ngon ngu lap trinh",
                    BlogPosts = blogPosts
                });
            return Ok(blogs);
        }
    }
}
