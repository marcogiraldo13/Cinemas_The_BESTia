using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DbContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<Function> Functions { get; set; }
        public DbSet<Seat> Seates { get; set; }
        public DbSet<SeatxFunction> SeatxFunction { get; set; }
    }
}
