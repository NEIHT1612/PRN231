﻿using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Author
    {
        public Author()
        {
            BookAuthors = new HashSet<BookAuthor>();
        }

        public int AuthorId { get; set; }
        public string LastName { get; set; } = null!;
        public string? FirstName { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zip { get; set; }
        public string? EmailAddress { get; set; }

        public virtual ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
