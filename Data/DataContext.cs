using LibraryCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryCRUD.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Book> Book { get; set; }
    }
}
