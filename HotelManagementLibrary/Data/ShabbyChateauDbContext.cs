using HotelManagementLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementLibrary.Data
{
    public class ShabbyChateauDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public ShabbyChateauDbContext()
        {

        }

        public ShabbyChateauDbContext(DbContextOptions<ShabbyChateauDbContext> options)
           : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.;Database=TheShabbyChateau;Trusted_Connection=True;TrustServerCertificate=true;");
            }
        }
    }
}
