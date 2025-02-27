﻿using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAuthorsAsync();
        Task<Author> GetAuthorAsync(int authorId);
        Task<Author> AddAuthorAsync(Author newAuthor);
        Task<Author> UpdateAuthorAsync(Author updateAuthor);
        Task DeleteAuthorAsync(int authorId);
    }
}
