using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieDetailsAPI.Models;

namespace MovieDetailsAPI.Data
{
    public class BookingDbContext : IdentityDbContext<ApplicationUser>
    {
        public BookingDbContext(DbContextOptions<BookingDbContext> options) : base(options) { }

        public DbSet<MovieBooking> MovieBookings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); 

            builder.Entity<MovieBooking>()
                .HasKey(b => b.Id); 
        }
    }
}
