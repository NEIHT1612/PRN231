namespace WebAPIOData2.Models
{
    public class DataSource
    {
        private static IList<Book> _books { get; set; }

        public static IList<Book> GetBooks()
        {
            if (_books != null)
            {
                return _books;
            }
            _books = new List<Book>();
            //book #1
            Book book = new Book
            {
                Id = 1,
                ISBN = "978-0-321-87758-1",
                Title = "Essential C#5.0",
                Author = "Mark Michaelis",
                Price = 59.99m,
                Location = new Address
                {
                    City = "HCM City",
                    Street = "D2, Thu Duc District"
                },
                Press = new Press
                {
                    Id = 1,
                    Name = "Addison-Wesley",
                    Email = "thiendt1@gmail.com",
                    Category = Category.Book,
                }
            };
            _books.Add(book);
            //book #2
            Book book2 = new Book
            {
                Id = 2,
                ISBN = "789-6-123-86544-3",
                Title = "Essential Java8.0",
                Author = "Michael Jackson",
                Price = 39.99m,
                Location = new Address
                {
                    City = "HN City",
                    Street = "Ba Dinh District"
                },
                Press = new Press
                {
                    Id = 2,
                    Name = "Donald-Trump",
                    Email = "thiendt2@gmail.com",
                    Category = Category.Magazine,
                }
            };
            _books.Add(book2);
            //book #3
            Book book3 = new Book
            {
                Id = 3,
                ISBN = "456-7-890-12345-6",
                Title = "Essential C++",
                Author = "Yilong Ma",
                Price = 89.99m,
                Location = new Address
                {
                    City = "Vinh City",
                    Street = "Le Hong Phong District"
                },
                Press = new Press
                {
                    Id = 3,
                    Name = "Abraham-Lincoln",
                    Email = "thiendt3@gmail.com",
                    Category = Category.EBook,
                }
            };
            _books.Add(book3);

            return _books;
        }
    }
}
