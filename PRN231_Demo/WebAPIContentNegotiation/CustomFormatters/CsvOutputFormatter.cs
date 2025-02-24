using Microsoft.AspNetCore.Mvc.Formatters;
using System.Text;
using WebAPIContentNegotiation.Models;

namespace WebAPIContentNegotiation.CustomFormatters
{
    public class CsvOutputFormatter : TextOutputFormatter
    {
        public CsvOutputFormatter() 
        {
            SupportedMediaTypes.Add("text/csv");
            SupportedEncodings.Add(Encoding.UTF8);
        }
        protected override bool CanWriteType(Type? type)
        {
            return typeof(IEnumerable<Blog>).IsAssignableFrom(type);
        }
        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;
            var blogs = (IEnumerable<Blog>)context.Object;
            await using (var writer = new StreamWriter(response.Body, selectedEncoding))
            {
                foreach (var blog in blogs)
                {
                    writer.WriteLine($"BlogID: {blog.BlogId}, BlogName: {blog.BlogName}, BlogDescription: {blog.BlogDescription}");
                    foreach(var post in blog.BlogPosts)
                    {
                        writer.WriteLine($"BlogPostID: {post.BlogPostId}, Title: {post.Title}, MetaDescription: {post.MetaDescription}, IsPublished: {post.IsPublished}");
                    }
                }
            }
        }
    }
}
