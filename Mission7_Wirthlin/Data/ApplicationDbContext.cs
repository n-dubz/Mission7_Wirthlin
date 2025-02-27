using Microsoft.EntityFrameworkCore;
using Mission7_Wirthlin.Models;

namespace Mission7_Wirthlin.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; } // Add this
    }
}