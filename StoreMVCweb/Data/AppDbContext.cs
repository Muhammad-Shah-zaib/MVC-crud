using Microsoft.EntityFrameworkCore;
using StoreMVCweb.Models;

namespace StoreMVCweb.Data
{
    public class AppDbContext : DbContext
    {
        // constructor for connecting with db
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
        // creating the table in the db
        public DbSet<Category> Categories { get; set; }
    }

    
}
