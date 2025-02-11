using Microsoft.EntityFrameworkCore;
using TravelApplication.Domain.Domain;

namespace TravelApplication.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Accommodation> Accommodations { get; set; }
        public DbSet<Activity> Activities { get; set; } // Ensure this is included
        public DbSet<Transport> Transports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // Configure the primary key for Destination
            modelBuilder.Entity<Destination>()
                .HasKey(d => d.TravelId);

            // Configure the primary key for Accommodation
            modelBuilder.Entity<Accommodation>()
                .HasKey(a => a.Id);

            // Configure the relationship between Accommodation and Destination
            modelBuilder.Entity<Accommodation>()
                .HasOne(a => a.Destination)
                .WithMany(d => d.Accomodations)
                .HasForeignKey(a => a.DestinationId);

            // Configure decimal precision for Activity.Cost
            modelBuilder.Entity<Activity>()
                .Property(a => a.Cost)
                .HasPrecision(18, 2); // 18 total digits, 2 decimal places

            // Configure decimal precision for Transport.CostPerPassenger
            modelBuilder.Entity<Transport>()
                .Property(t => t.CostPerPassenger)
                .HasPrecision(18, 2);
        }
    }
}