using Library.Model;
using Microsoft.EntityFrameworkCore;

namespace Library.Database
{
    public class LibraryContext:DbContext
    {
        public DbSet<Books> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genres> Genres { get; set; }
    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            // name of database
            optionsBuilder.UseSqlite(@"Data Source = C:\Users\hanch\Desktop\school\Exercises\DNP\Session9\Library\Library.db");
        }
    }

    
}