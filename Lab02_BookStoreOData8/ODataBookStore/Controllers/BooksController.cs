using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using ODataBookStore.Models;

namespace ODataBookStore.Controllers
{
    public class BooksController : ODataController
    {
        private BookStoreContext db;
        public BooksController(BookStoreContext context)
        {
            db = context;
            db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            if (context.Books.Count() == 0)
            {
                foreach (var b in DataSource.GetBooks())
                {
                    context.Books.Add(b);
                    context.Presses.Add(b.Press);
                }
                context.SaveChanges();
            }
        }

        [EnableQuery(PageSize = 10)]
        public IActionResult Get() 
        {
            return Ok(db.Books);
        }

        [EnableQuery]
        public IActionResult Get(int key, string version)
        {
            return Ok(db.Books.FirstOrDefault(b => b.Id == key));
        }

        [HttpPost]
        [EnableQuery]
        public IActionResult Post([FromBody] Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
            return NoContent();
        }

        [EnableQuery]
        public IActionResult Put([FromODataUri] int key, [FromBody] Book book)
        {
            Book b = db.Books.FirstOrDefault(b => b.Id == key);
            if (b == null)
            {
                return NotFound();
            }
            b.ISBN = book.ISBN;
            b.Title = book.Title;
            b.Price = book.Price;
            b.Author = book.Author;
            b.Location.City = book.Location.City;
            b.Location.Street = book.Location.Street;
            db.Books.Update(b);
            db.SaveChanges();
            return Updated(b);
        }

        [EnableQuery]
        public IActionResult Delete([FromODataUri] int key)
        {
            Book b = db.Books.FirstOrDefault(b => b.Id == key);
            if (b == null)
            {
                return NotFound();
            }
            db.Books.Remove(b);
            db.SaveChanges();
            return Ok();
        }
    }
}
