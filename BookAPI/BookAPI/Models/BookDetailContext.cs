using Microsoft.EntityFrameworkCore;

namespace BookAPI.Models
{
    public class BookDetailContext : DbContext
    {
        public BookDetailContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BookDetail> BookDetails { get; set; }
    }
}
