using Microsoft.EntityFrameworkCore;
using MovieWebApplication1.Models;

namespace MovieWebApplication1.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Acotrs { get; set; }
    }
}
