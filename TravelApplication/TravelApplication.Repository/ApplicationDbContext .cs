using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApplication.Domain.Domain.MainModels;
using TravelApplication.Domain.Domain.MappingModels;
using TravelApplication.Domain.Identity;

namespace TravelApplication.Repository
{
    public class ApplicationDbContext : IdentityDbContext<TravelApplicationUser>
    {
        public virtual DbSet<Accommodation> Accommodations { get; set; }
        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<Attraction> Attractions { get; set; }
        public virtual DbSet<Destination> Destinations { get; set; }

        public virtual DbSet<Meal> Meals { get; set; }
        public virtual DbSet<Transport> Transports { get; set; }
        public virtual DbSet<TravelPackage> TravelPackages { get; set; }
        public virtual DbSet<TravelPackageAccommodation> TravelPackageAccommodations { get; set; }
        public virtual DbSet<TravelPackageActivity> TravelPackageActivities { get; set; }
        public virtual DbSet<TravelPackageAttraction> TravelPackageAttractions { get; set; }
        public virtual DbSet<TravelPackageMeal> TravelPackageMeals { get; set; }
        public virtual DbSet<TravelPackageTransport> TravelPackageTransports { get; set; }
        public virtual DbSet<TravelApplicationUser> TravelApplicationUsers{ get; set; }

        public virtual DbSet<Booking> Bookings  { get; set; }

        public virtual DbSet<Itinerary> Itineraries { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TravelPackageAccommodation>()
            .Property(e => e.Id)
    .       ValueGeneratedOnAdd();

            modelBuilder.Entity<TravelPackageActivity>()
            .Property(e => e.Id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<TravelPackageAttraction>()
            .Property(e => e.Id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<TravelPackageMeal>()
            .Property(e => e.Id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<TravelPackageTransport>()
            .Property(e => e.Id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<Accommodation>()
                .Property(a => a.PricePerNight)
                .HasColumnType("decimal(18,2)");  

            modelBuilder.Entity<Activity>()
                .Property(a => a.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Attraction>()
                .Property(a => a.EntryFee)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Meal>()
                .Property(m => m.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Transport>()
                .Property(t => t.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<TravelPackage>()
                .Property(t => t.TotalPrice)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.TravelPackage)
                .WithMany(tp => tp.Bookings) 
                .HasForeignKey(b => b.TravelPackageId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.User)
                .WithMany(b => b.Bookings) 
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
