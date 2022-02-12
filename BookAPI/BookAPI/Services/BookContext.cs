using BookAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookAPI.Services
{
    public class BookContext : DbContext
    {
        public BookContext( DbContextOptions<BookContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Book> Books { get; set; }
    }
}
