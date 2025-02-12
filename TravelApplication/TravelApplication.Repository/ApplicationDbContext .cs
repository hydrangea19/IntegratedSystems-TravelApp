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
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Transport> Transports { get; set; }
        public DbSet<DestinationActivity> DestinationActivities { get; set; }
        public DbSet<DestinationTransport> DestinationTransports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Destination>()
                .HasKey(d => d.TravelId);

            modelBuilder.Entity<Accommodation>()
                .HasOne(a => a.Destination)
                .WithMany(d => d.Accommodations)
                .HasForeignKey(a => a.DestinationId);

            modelBuilder.Entity<DestinationActivity>()
           .HasKey(da => new { da.DestinationId, da.ActivityId });

            modelBuilder.Entity<DestinationActivity>()
                .HasOne(da => da.Destination)
                .WithMany(d => d.DestinationActivities)
                .HasForeignKey(da => da.DestinationId);

            modelBuilder.Entity<DestinationActivity>()
                .HasOne(da => da.Activity)
                .WithMany(a => a.DestinationActivities)
                .HasForeignKey(da => da.ActivityId);

            modelBuilder.Entity<DestinationTransport>()
        .HasKey(dt => new { dt.DestinationId, dt.TransportId });

            modelBuilder.Entity<DestinationTransport>()
                .HasOne(dt => dt.Destination)
                .WithMany(d => d.DestinationTransports)
                .HasForeignKey(dt => dt.DestinationId);

            modelBuilder.Entity<DestinationTransport>()
                .HasOne(dt => dt.Transport)
                .WithMany(t => t.DestinationTransports)
                .HasForeignKey(dt => dt.TransportId);

            modelBuilder.Entity<Activity>()
                .Property(a => a.Cost)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Transport>()
                .Property(t => t.CostPerPassenger)
                .HasPrecision(18, 2);
        }
    }
}
