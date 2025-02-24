using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using WebAPIOData2.Models;

namespace WebAPIOData2.Controllers
{
    public class BooksController : ODataController
    {
        private readonly BookStoreContext _context;

        public BooksController(BookStoreContext context)
        {
            _context = context;
            if (context.Books.Count() == 0)
            {
                foreach (var book in DataSource.GetBooks())
                {
                    context.Books.Add(book);
                    context.Presses.Add(book.Press);
                }
                context.SaveChanges();
            }
        }

        [EnableQuery(PageSize = 10)]
        public IActionResult Get() => Ok(_context.Books);

        [EnableQuery, HttpPost]
        public IActionResult Post([FromBody]Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();

            return Created("Get", book);
        }

        [EnableQuery]
        public IActionResult Delete([FromODataUri] int key)
        {
            var b = _context.Books.FirstOrDefault(x => x.Id == key);
            if(b == null)
            {
                return NotFound();
            }
            _context.Books.Remove(b);
            _context.SaveChanges();

            return NoContent();
        }

        [EnableQuery]
        public IActionResult Get(int key)
        {
            return Ok(_context.Books.FirstOrDefault(x => x.Id == key));
        }

        [EnableQuery]
        public IActionResult Put([FromODataUri] int key, [FromBody] Book book)
        {
            Book currentBook = _context.Books.FirstOrDefault(x => x.Id == key);
            if (currentBook == null)
            {
                return NotFound();
            }
            currentBook.ISBN = book.ISBN;
            currentBook.Title = book.Title;
            currentBook.Author = book.Author;
            currentBook.Price = book.Price;
            currentBook.Location.City = book.Location.City;
            currentBook.Location.Street = book.Location.Street;
            _context.Books.Update(currentBook);
            _context.SaveChanges();
            return Updated(currentBook);
        }
    }
}
