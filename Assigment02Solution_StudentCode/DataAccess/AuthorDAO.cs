using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AuthorDAO
    {
        private static AuthorDAO instance = null;
        private static readonly object instanceLock = new object();
        private AuthorDAO() { }
        public static AuthorDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new AuthorDAO();

                    }
                    return instance;
                }
            }
        }
        public async Task<IEnumerable<Author>> GetAuthorsAsync()
        {
            var db = new eBookStoreContext();
            return await db.Authors.ToListAsync();
        }
        public async Task<Author> GetAuthorAsync(int AuthorId)
        {
            var db = new eBookStoreContext();
            return await db.Authors.FindAsync(AuthorId);

        }
        public async Task<Author> AddAuthorAsync(Author author)
        {
            var db = new eBookStoreContext();
            await db.Authors.AddAsync(author);
            await db.SaveChangesAsync();
            return author;

        }
        public async Task<Author> UpdateAuthorAsync(Author author)
        {
            if (await GetAuthorAsync(author.AuthorId) == null)
            {
                throw new ApplicationException("NotFound");
            }
            var db = new eBookStoreContext();
            db.Authors.Update(author);
            await db.SaveChangesAsync();
            return author;
        }
        public async Task DeleteAuthorAsync(int authorId)
        {
            Author author = await GetAuthorAsync(authorId);
            if (author == null)
            {
                throw new ApplicationException(" not fornd");

            }
            var db = new eBookStoreContext();
            db.Authors.Remove(author);
            await db.SaveChangesAsync();
        }
    }
}
