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

            modelBuilder.Entity<Staff>().Property(x => x.Salary).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<Booking>().Property(x => x.TotalPrice).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<RoomType>().Property(x => x.PricePerNight).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<Payment>().Property(x => x.Amount).HasColumnType("decimal(10,2)");



            base.OnModelCreating(modelBuilder);
        }

    }
}
