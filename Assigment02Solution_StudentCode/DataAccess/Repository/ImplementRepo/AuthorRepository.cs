using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.ImplementRepo
{
    public class AuthorRepository : IAuthorRepository
    {
        public async Task<Author> AddAuthorAsync(Author newAuthor)
            => await AuthorDAO.Instance.AddAuthorAsync(newAuthor);

        public async Task DeleteAuthorAsync(int authorId)
            => await AuthorDAO.Instance.DeleteAuthorAsync(authorId);

        public async Task<Author> GetAuthorAsync(int authorId)
            => await AuthorDAO.Instance.GetAuthorAsync(authorId);

        public async Task<IEnumerable<Author>> GetAuthorsAsync()
            => await AuthorDAO.Instance.GetAuthorsAsync();

        public async Task<Author> UpdateAuthorAsync(Author updateAuthor)
            => await AuthorDAO.Instance.UpdateAuthorAsync(updateAuthor);
    }
}
