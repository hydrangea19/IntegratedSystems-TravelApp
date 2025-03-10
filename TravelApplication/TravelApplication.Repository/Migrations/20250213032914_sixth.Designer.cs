﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelApplication.Repository;

#nullable disable

namespace TravelApplication.Repository.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250213032914_sixth")]
    partial class sixth
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("TravelApplication.Domain.Domain.MainModels.Accommodation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<string>("Amenities")
                        .HasColumnType("longtext");

                    b.Property<string>("City")
                        .HasColumnType("longtext");

                    b.Property<string>("ContactNumber")
                        .HasColumnType("longtext");

                    b.Property<string>("Country")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("PricePerNight")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("Stars")
                        .HasColumnType("int");

                    b.Property<int?>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Website")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Accommodations");
                });

            modelBuilder.Entity("TravelApplication.Domain.Domain.MainModels.Activity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int?>("ActivityType")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<TimeSpan?>("Duration")
                        .HasColumnType("time(6)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("Location")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("TravelApplication.Domain.Domain.MainModels.Attraction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<TimeSpan?>("ClosingTime")
                        .HasColumnType("time(6)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<decimal>("EntryFee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("Location")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<TimeSpan?>("OpeningTime")
                        .HasColumnType("time(6)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Attractions");
                });

            modelBuilder.Entity("TravelApplication.Domain.Domain.MainModels.Destination", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int?>("Climate")
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Destinations");
                });

            modelBuilder.Entity("TravelApplication.Domain.Domain.MainModels.Meal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Cuisine")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("longtext");

                    b.Property<bool?>("IsHalal")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("IsVegetarian")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Meals");
                });

            modelBuilder.Entity("TravelApplication.Domain.Domain.MainModels.Transport", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("ArrivalTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DepartureTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("From")
                        .HasColumnType("longtext");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Provider")
                        .HasColumnType("longtext");

                    b.Property<string>("To")
                        .HasColumnType("longtext");

                    b.Property<int?>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Transports");
                });

            modelBuilder.Entity("TravelApplication.Domain.Domain.MainModels.TravelPackage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<Guid?>("DestinationId")
                        .HasColumnType("char(36)");

                    b.Property<int?>("DurationInDays")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("longtext");

                    b.Property<bool?>("IsCustomizable")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("DestinationId");

                    b.ToTable("TravelPackages");
                });

            modelBuilder.Entity("TravelApplication.Domain.Domain.MappingModels.TravelPackageAccommodation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("AccommodationId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("PackageId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("TravelPackageId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("AccommodationId");

                    b.HasIndex("TravelPackageId");

                    b.ToTable("TravelPackageAccommodations");
                });

            modelBuilder.Entity("TravelApplication.Domain.Domain.MappingModels.TravelPackageActivity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ActivityId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("PackageId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("TravelPackageId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("ActivityId");

                    b.HasIndex("TravelPackageId");

                    b.ToTable("TravelPackageActivities");
                });

            modelBuilder.Entity("TravelApplication.Domain.Domain.MappingModels.TravelPackageAttraction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("AttractionId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("PackageId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("TravelPackageId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("AttractionId");

                    b.HasIndex("TravelPackageId");

                    b.ToTable("TravelPackageAttractions");
                });

            modelBuilder.Entity("TravelApplication.Domain.Domain.MappingModels.TravelPackageMeal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("MealId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("PackageId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("TravelPackageId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("MealId");

                    b.HasIndex("TravelPackageId");

                    b.ToTable("TravelPackageMeals");
                });

            modelBuilder.Entity("TravelApplication.Domain.Domain.MappingModels.TravelPackageTransport", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("PackageId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("TransportId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("TravelPackageId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("TransportId");

                    b.HasIndex("TravelPackageId");

                    b.ToTable("TravelPackageTransports");
                });

            modelBuilder.Entity("TravelApplication.Domain.Identity.TravelApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<DateTime?>("dateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("firstName")
                        .HasColumnType("longtext");

                    b.Property<string>("lastName")
                        .HasColumnType("longtext");

                    b.Property<string>("profilePictureUrl")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("TravelApplication.Domain.Identity.TravelApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("TravelApplication.Domain.Identity.TravelApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelApplication.Domain.Identity.TravelApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("TravelApplication.Domain.Identity.TravelApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TravelApplication.Domain.Domain.MainModels.TravelPackage", b =>
                {
                    b.HasOne("TravelApplication.Domain.Domain.MainModels.Destination", "Destination")
                        .WithMany("TravelPackages")
                        .HasForeignKey("DestinationId");

                    b.Navigation("Destination");
                });

            modelBuilder.Entity("TravelApplication.Domain.Domain.MappingModels.TravelPackageAccommodation", b =>
                {
                    b.HasOne("TravelApplication.Domain.Domain.MainModels.Accommodation", "Accommodation")
                        .WithMany()
                        .HasForeignKey("AccommodationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelApplication.Domain.Domain.MainModels.TravelPackage", null)
                        .WithMany("PackageAccommodations")
                        .HasForeignKey("TravelPackageId");

                    b.Navigation("Accommodation");
                });

            modelBuilder.Entity("TravelApplication.Domain.Domain.MappingModels.TravelPackageActivity", b =>
                {
                    b.HasOne("TravelApplication.Domain.Domain.MainModels.Activity", "Activity")
                        .WithMany("PackageActivities")
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelApplication.Domain.Domain.MainModels.TravelPackage", "TravelPackage")
                        .WithMany("PackageActivities")
                        .HasForeignKey("TravelPackageId");

                    b.Navigation("Activity");

                    b.Navigation("TravelPackage");
                });

            modelBuilder.Entity("TravelApplication.Domain.Domain.MappingModels.TravelPackageAttraction", b =>
                {
                    b.HasOne("TravelApplication.Domain.Domain.MainModels.Attraction", "Attraction")
                        .WithMany("PackageAttractions")
                        .HasForeignKey("AttractionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelApplication.Domain.Domain.MainModels.TravelPackage", "TravelPackage")
                        .WithMany("PackageAttractions")
                        .HasForeignKey("TravelPackageId");

                    b.Navigation("Attraction");

                    b.Navigation("TravelPackage");
                });

            modelBuilder.Entity("TravelApplication.Domain.Domain.MappingModels.TravelPackageMeal", b =>
                {
                    b.HasOne("TravelApplication.Domain.Domain.MainModels.Meal", "Meal")
                        .WithMany("PackageMeals")
                        .HasForeignKey("MealId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelApplication.Domain.Domain.MainModels.TravelPackage", "TravelPackage")
                        .WithMany("PackageMeals")
                        .HasForeignKey("TravelPackageId");

                    b.Navigation("Meal");

                    b.Navigation("TravelPackage");
                });

            modelBuilder.Entity("TravelApplication.Domain.Domain.MappingModels.TravelPackageTransport", b =>
                {
                    b.HasOne("TravelApplication.Domain.Domain.MainModels.Transport", "Transport")
                        .WithMany("PackageTransports")
                        .HasForeignKey("TransportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelApplication.Domain.Domain.MainModels.TravelPackage", "TravelPackage")
                        .WithMany("PackageTransports")
                        .HasForeignKey("TravelPackageId");

                    b.Navigation("Transport");

                    b.Navigation("TravelPackage");
                });

            modelBuilder.Entity("TravelApplication.Domain.Domain.MainModels.Activity", b =>
                {
                    b.Navigation("PackageActivities");
                });

            modelBuilder.Entity("TravelApplication.Domain.Domain.MainModels.Attraction", b =>
                {
                    b.Navigation("PackageAttractions");
                });

            modelBuilder.Entity("TravelApplication.Domain.Domain.MainModels.Destination", b =>
                {
                    b.Navigation("TravelPackages");
                });

            modelBuilder.Entity("TravelApplication.Domain.Domain.MainModels.Meal", b =>
                {
                    b.Navigation("PackageMeals");
                });

            modelBuilder.Entity("TravelApplication.Domain.Domain.MainModels.Transport", b =>
                {
                    b.Navigation("PackageTransports");
                });

            modelBuilder.Entity("TravelApplication.Domain.Domain.MainModels.TravelPackage", b =>
                {
                    b.Navigation("PackageAccommodations");

                    b.Navigation("PackageActivities");

                    b.Navigation("PackageAttractions");

                    b.Navigation("PackageMeals");

                    b.Navigation("PackageTransports");
                });
#pragma warning restore 612, 618
        }
    }
}
