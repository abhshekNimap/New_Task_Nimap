using Microsoft.EntityFrameworkCore;
using NewMovieReleaseAPI.Models;

namespace NewMovieReleaseAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Movie> Movies { get; set; }

    }
}
