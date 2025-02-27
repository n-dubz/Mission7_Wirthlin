using Microsoft.EntityFrameworkCore;
using Mission7_Wirthlin.Models;

namespace Mission7_Wirthlin.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().ToTable("Movies"); // Explicitly set table name
        }
        public DbSet<Movie> Movies { get; set; }
    }
    
}
