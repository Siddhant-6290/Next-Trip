using Microsoft.EntityFrameworkCore;
using System;
using TMS.Models;

namespace TMS.Data
{
    public class TourismContext : DbContext
    {
        public TourismContext(DbContextOptions<TourismContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<TourPackage> TourPackages { get; set; } = null!;
        public DbSet<Booking> Bookings { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Users
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Admin", Email = "admin@test.com", Password = "admin123", Role = "Admin" },
                new User { Id = 2, Name = "John Doe", Email = "john@test.com", Password = "john123", Role = "Customer" },
                new User { Id = 3, Name = "Jane Smith", Email = "jane@test.com", Password = "jane123", Role = "Customer" }
            );

            // Seed Tour Packages with Images
            modelBuilder.Entity<TourPackage>().HasData(
                new TourPackage
                {
                    Id = 1,
                    Title = "Goa Beach Trip",
                    Description = "3 Days/2 Nights Goa Tour",
                    Price = 5000,
                    ImageUrl = "/images/goa.jpg"
                },
                new TourPackage
                {
                    Id = 2,
                    Title = "Himalaya Trek",
                    Description = "5 Days Trekking in Himalayas",
                    Price = 12000,
                    ImageUrl = "/images/himalaya.jpg"
                },
                new TourPackage
                {
                    Id = 3,
                    Title = "Kerala Backwaters",
                    Description = "4 Days Houseboat Tour",
                    Price = 8000,
                    ImageUrl = "/images/kerala.jpg"
                }
            );

            // Seed Bookings
            modelBuilder.Entity<Booking>().HasData(
                new Booking
                {
                    Id = 1,
                    UserId = 2,
                    TourPackageId = 1,
                    BookingDate = DateTime.Now.AddDays(10),
                    Seats = 2,
                    AmountPaid = 10000,
                    ConfirmedOn = DateTime.Now
                },
                new Booking
                {
                    Id = 2,
                    UserId = 3,
                    TourPackageId = 3,
                    BookingDate = DateTime.Now.AddDays(5),
                    Seats = 1,
                    AmountPaid = 8000,
                    ConfirmedOn = DateTime.Now
                }
            );



        }
    }
}
