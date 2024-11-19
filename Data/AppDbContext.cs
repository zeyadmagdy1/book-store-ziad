using book_store_ziad.Models.Authorr;
using book_store_ziad.Models.Bookk;
using book_store_ziad.Models.CeridetCardd;
using book_store_ziad.Models.Genree;
using book_store_ziad.Models.IdentityCardd;
using Microsoft.EntityFrameworkCore;

namespace book_store_ziad.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Book> books { get; set; }

        public DbSet<Author> authors { get; set; }

        public DbSet<IdentityCard> identityCards { get; set; }

        public DbSet<CeridetCard> ceridetCards { get; set; }

    }
}
