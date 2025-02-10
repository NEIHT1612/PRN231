using Microsoft.EntityFrameworkCore;

namespace WebDemo
{
    public class TodoItemContext : DbContext
    {
        public TodoItemContext(DbContextOptions<TodoItemContext> options) : base(options) { }
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
