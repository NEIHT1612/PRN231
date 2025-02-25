using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BookDAO
    {
        private static BookDAO instance;
        private static readonly object instanceLock = new object();
        private BookDAO()
        {
        }
        public static BookDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new BookDAO();
                    }
                    return instance;
                }
            }
        }
        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            var db = new eBookStoreContext();
            return await db.Books.Include(b => b.Pub).ToListAsync();

        }
        public async Task<Book> GetBookAsync(int bookId)
        {
            var db = new eBookStoreContext();
            return await db.Books
                .Include(book => book.Pub)
                .SingleOrDefaultAsync(book => book.BookId == bookId);
        }

        public async Task<Book> AddBookAsync(Book newBook)
        {
            var db = new eBookStoreContext();
            await db.Books.AddAsync(newBook);
            await db.SaveChangesAsync();

            return newBook;
        }

        public async Task<Book> UpdateBookAsync(Book updatedBook)
        {
            if (await GetBookAsync(updatedBook.BookId) == null)
            {
                throw new ApplicationException("Book does not exist!!");
            }
            var db = new eBookStoreContext();
            db.Books.Update(updatedBook);
            await db.SaveChangesAsync();
            return updatedBook;
        }

        public async Task DeleteBookAsync(int bookId)
        {
            Book deletedBook = await GetBookAsync(bookId);
            if (deletedBook == null)
            {
                throw new ApplicationException("Book does not exist!!");
            }
            var db = new eBookStoreContext();
            db.Books.Remove(deletedBook);
            await db.SaveChangesAsync();
        }
    }
}
