using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using WebAPIOData2.Models;

namespace WebAPIOData2.Controllers
{
    public class PressesController : ODataController
    {
        private readonly BookStoreContext _context;
        public PressesController(BookStoreContext context)
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

        [EnableQuery, HttpGet]
        public IActionResult Get() => Ok(_context.Presses);

        [EnableQuery, HttpGet]
        public IActionResult Get([FromODataUri] int key)
        {
            return Ok(_context.Presses.FirstOrDefault(x => x.Id == key));
        }

        [EnableQuery, HttpPost]
        public IActionResult Post([FromBody]Press press)
        {
            _context.Presses.Add(press);
            _context.SaveChanges();
            return Created("Get", press);
        }

        [EnableQuery]
        public IActionResult Delete([FromODataUri] int key)
        {
            List<Book> books = _context.Books.Where(x => x.Press.Id == key).ToList();
            foreach (var item in books)
            {
                _context.Remove(item);
            }
            Press press = _context.Presses.FirstOrDefault(x => x.Id == key);
            _context.Remove(press);
            _context.SaveChanges();
            return NoContent();
        }

        [EnableQuery]
        [HttpPut]
        public IActionResult Put(int key, [FromBody]Press press)
        {
            Press currentPress = _context.Presses.FirstOrDefault(x => x.Id == 1);
            if (currentPress == null)
            {
                return NotFound();
            }
            currentPress.Name = press.Name;
            currentPress.Email = press.Email;
            currentPress.Category = press.Category;
            _context.Presses.Update(currentPress);
            _context.SaveChanges();
            return Updated(currentPress);
        }
    }
}
