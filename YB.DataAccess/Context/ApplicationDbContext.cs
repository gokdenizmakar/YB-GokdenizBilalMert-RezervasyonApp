using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YB.Entities.Abstraction;
using YB.Entities.Models;

namespace YB.DataAccess.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Guest> Guests { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Gökdeniz dbcontext
            //optionsBuilder.UseSqlServer("Data Source=DESKTOP-F07Q5IB; Initial Catalog=YBRezervasyonDB; Integrated Security=True;Connect Timeout=30;Encrypt=True; Trust Server Certificate=True;");

            //Bilal dbcontext
            //optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=YBRezervasyonDB;Integrated Security=True;Trust Server Certificate=False;");

            //Mert dbcontext
            optionsBuilder.UseSqlServer("Data Source=MERT\\SQLEXPRESS;initial catalog=YBRezervasyonDB;Integrated Security=True;Connect Timeout=30;Encrypt=True; Trust Server Certificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
                .HasKey(b => b.ID);
            modelBuilder.Entity<Guest>()
                .HasKey(b => b.ID);
            modelBuilder.Entity<Hotel>()
                .HasKey(b => b.ID);
            modelBuilder.Entity<Staff>()
                .HasKey(b => b.ID);
            modelBuilder.Entity<RoomType>()
                .HasKey(b => b.ID);
            modelBuilder.Entity<Room>()
                .HasKey(b => b.ID);
            modelBuilder.Entity<Payment>()
                .HasKey(b => b.ID);

            modelBuilder.Entity<Guest>().Ignore(x => x.FullName);

            modelBuilder.Entity<Staff>().Property(x => x.Salary).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<Booking>().Property(x => x.TotalPrice).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<RoomType>().Property(x => x.PricePerNight).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<Payment>().Property(x => x.Amount).HasColumnType("decimal(10,2)");

            modelBuilder.Entity<Hotel>().HasData(
                  new Hotel()
                  {
                      Name = "Paradise Hotel",
                      Stars = 5,
                      Phone = "00000000000",
                      Address = "Paradise Hotel'in yanındaki binanın yanındaki binası.",
                      Email = "paradise@hotmail.com",
                      CheckinTime = new TimeSpan(14, 0, 0),
                      CheckoutTime = new TimeSpan(12, 0, 0)
                  },
                  new Hotel()
                  {
                     Name = "Selge Beach Hotel",
                     Stars = 3,
                     Phone = "00000000000",
                     Address = "Antalya'daki Paradise Hotel'in yanı.",
                     Email = "selgebeach@hotmail.com",
                    CheckinTime = new TimeSpan(14, 0, 0),
                     CheckoutTime = new TimeSpan(12, 0, 0)
                  },
                  new Hotel()
                  {
                    Name = "Caprice Hotel",
                    Stars = 4,
                    Phone = "00000000000",
                    Address = "Antalya'daki Selge Beach Hotel'in yanı.",
                    Email = "caprice@hotmail.com",
                    CheckinTime = new TimeSpan(14, 0, 0),
                    CheckoutTime = new TimeSpan(12, 0, 0)
                  },
                 new Hotel()
                 {
                    Name = "Anormal Hotel",
                    Stars = 1,
                    Phone = "00000000000",
                    Address = "Adana",
                    Email = "anormalmiyim@hotmail.com",
                    CheckinTime = new TimeSpan(14, 0, 0),
                    CheckoutTime = new TimeSpan(12, 0, 0)
                 });
            modelBuilder.Entity<RoomType>().HasData(
                new RoomType
                {
                    Name = "Single",
                    Capacity = 1,
                    Description = "Manitle gelme",
                    PricePerNight = 100,
                },
                 new RoomType
                 {
                     Name = "Double",
                     Capacity = 2,
                     Description = "Manitle gel",
                     PricePerNight = 150,
                 },
                  new RoomType
                  {
                      Name = "Triple",
                      Capacity = 3,
                      Description = "Tek çocukla gel",
                      PricePerNight = 200,
                  },
                  new RoomType
                  {
                      Name = "Suit",
                      Capacity = 4,
                      Description = "Aile ocağı",
                      PricePerNight = 400,
                  }
            );


            base.OnModelCreating(modelBuilder);
        }

    }
}
