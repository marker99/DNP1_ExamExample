using AuthorAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthorAPI.Persistence
{
    public class LibraryContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //name of database
            optionsBuilder.UseSqlite(@"Data Source = C:\Users\frede\RiderProjects\DNP1_ExamExample\AuthorAPI\Library.db");
        }
    }
}