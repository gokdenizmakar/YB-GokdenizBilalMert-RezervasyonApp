using Microsoft.EntityFrameworkCore;
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
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-F07Q5IB; Initial Catalog=YBRezervasyonDB; Integrated Security=True;Connect Timeout=30;Encrypt=True; Trust Server Certificate=True;");

            //Bilal dbcontext
            //optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=YBRezervasyonDB;Integrated Security=True;Trust Server Certificate=False;");

            //Mert dbcontext
            //optionsBuilder.UseSqlServer("Data Source=MERT\\SQLEXPRESS;initial catalog=YBRezervasyonDB;Integrated Security=True;Connect Timeout=30;Encrypt=True; Trust Server Certificate=True;");

            //bll bpc21
            optionsBuilder.UseSqlServer("Data Source=BPC21; Initial Catalog=YBRezervasyonDB; Integrated Security=True;Connect Timeout=30;Encrypt=True; Trust Server Certificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Guest>().Ignore(x => x.FullName);

            modelBuilder.Entity<Staff>().Property(x => x.Salary).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<Booking>().Property(x => x.TotalPrice).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<Room>().Property(x => x.PricePerNight).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<Payment>().Property(x => x.Amount).HasColumnType("decimal(10,2)");


            var HotelId4 = Guid.Parse("4F6B4B97-1288-44E8-BE28-F142F318B080");
            var HotelId1 = Guid.Parse("2545701B-8CE9-45C7-A563-41D5753E3560");
            var HotelId2 = Guid.Parse("4DC67C0C-0D73-421F-AF3C-0F0D3605DB4F");
            var HotelId3 = Guid.Parse("2415CBC9-DEB9-4AFA-AFE8-4EB8BDA9B3DF");

            var RoomTypeId4 = Guid.Parse("BF6F8E6B-7AAB-4422-B0D2-4B64D37D763D");
            var RoomTypeId1 = Guid.Parse("A705B8F5-594C-4BD8-B099-5F017576FBFB");
            var RoomTypeId2 = Guid.Parse("AF771CBA-903F-44AB-A5D6-80C956C5D71B");
            var RoomTypeId3 = Guid.Parse("2F7DEC9E-2B10-41E3-87E1-3CB2B4A03211");


            modelBuilder.Entity<Booking>()
           .HasMany(b => b.Guests)
           .WithMany(g => g.Bookings)
           .UsingEntity(j => j.ToTable("BookingGuest"));


            modelBuilder.Entity<Hotel>().HasData(
                  new Hotel()
                  {
                      ID = HotelId4,
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
                      ID = HotelId1,
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
                      ID = HotelId2,
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
                     ID = HotelId3,
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
                    ID = RoomTypeId1,
                    Name = "Single",
                    Capacity = 1,
                    Description = "Manitle gelme",
                },
                 new RoomType
                 {
                     ID = RoomTypeId2,
                     Name = "Double",
                     Capacity = 2,
                     Description = "Manitle gel",
                 },
                  new RoomType
                  {
                      ID = RoomTypeId3,
                      Name = "Triple",
                      Capacity = 3,
                      Description = "Tek çocukla gel",
                  },
                  new RoomType
                  {
                      ID = RoomTypeId4,
                      Name = "Suit",
                      Capacity = 4,
                      Description = "Aile ocağı",
                  });
            modelBuilder.Entity<Room>().HasData(
               new Room
               {
                   ID = Guid.Parse("7179234B-D785-4602-9CB1-50786652C079"),
                   HotelID = HotelId1,//3 yıldızlı
                   RoomTypeID = RoomTypeId1,
                   RoomNumber = "101",
                   Status = "Available",
                   PricePerNight = 300
               },
               new Room
               {
                   ID = Guid.Parse("E43D98B9-06A6-467C-8DB6-7235F49C3E86"),
                   HotelID = HotelId1,
                   RoomTypeID = RoomTypeId2,
                   RoomNumber = "201",
                   Status = "Available",
                   PricePerNight = 400
               },
               new Room
               {
                   ID = Guid.Parse("C89613D6-69E3-47E2-987F-052F80ECAC9D"),
                   HotelID = HotelId1,
                   RoomTypeID = RoomTypeId3,
                   RoomNumber = "301",
                   Status = "Available",
                   PricePerNight = 500
               },
               new Room
               {
                   ID = Guid.Parse("07919E09-37E7-4CD3-8C11-08AE41EB5C82"),
                   HotelID = HotelId1,
                   RoomTypeID = RoomTypeId4,
                   RoomNumber = "401",
                   Status = "Available",
                   PricePerNight = 600
               },
                // Selge Beach Hotel
                new Room
                {
                    ID = Guid.Parse("3351787F-F12A-43E1-81A8-855A7A70C5C2"),
                    HotelID = HotelId2,
                    RoomTypeID = RoomTypeId1,
                    RoomNumber = "101",
                    Status = "Available",
                    PricePerNight = 400
                },
                new Room
                {
                    ID = Guid.Parse("17B89311-D8A4-4B49-9BC8-6E8FF59683F9"),
                    HotelID = HotelId2,
                    RoomTypeID = RoomTypeId2,
                    RoomNumber = "201",
                    Status = "Available",
                    PricePerNight = 500
                },
                new Room
                {
                    ID = Guid.Parse("512A0A0D-0566-42F6-9AF0-66D871B537F7"),
                    HotelID = HotelId2,
                    RoomTypeID = RoomTypeId3,
                    RoomNumber = "301",
                    Status = "Available",
                    PricePerNight = 600
                },
                new Room
                {
                    ID = Guid.Parse("2A34881E-E18B-4101-BD2F-4BDA1A7E6398"),
                    HotelID = HotelId2,
                    RoomTypeID = RoomTypeId4,
                    RoomNumber = "401",
                    Status = "Available",
                    PricePerNight = 700
                },
                 // Caprice Hotel
                 new Room
                 {
                     ID = Guid.Parse("5FF99E74-0A39-4838-8743-460564B6884F"),
                     HotelID = HotelId3,
                     RoomTypeID = RoomTypeId1,
                     RoomNumber = "101",
                     Status = "Available",
                     PricePerNight = 100
                 },
                 new Room
                 {
                     ID = Guid.Parse("7F284F12-2EC7-4B6D-9B5C-52EE7218CD62"),
                     HotelID = HotelId3,
                     RoomTypeID = RoomTypeId2,
                     RoomNumber = "201",
                     Status = "Available",
                     PricePerNight = 200
                 },
                 new Room
                 {
                     ID = Guid.Parse("312EC489-0B20-465B-A724-228E00B6B29E"),
                     HotelID = HotelId3,
                     RoomTypeID = RoomTypeId3,
                     RoomNumber = "301",
                     Status = "Available",
                     PricePerNight = 300
                 },
                new Room
                {
                    ID = Guid.Parse("68F2E855-612E-42AD-89CA-14FAF1F880D0"),
                    HotelID = HotelId3,
                    RoomTypeID = RoomTypeId4,
                    RoomNumber = "401",
                    Status = "Available",
                    PricePerNight = 400
                },
                // Anormal Hotel
                new Room
                {
                    ID = Guid.Parse("6DC705C3-329E-44A3-A261-54824DD618F3"),
                    HotelID = HotelId4,
                    RoomTypeID = RoomTypeId1,
                    RoomNumber = "101",
                    Status = "Available",
                    PricePerNight = 500
                },
                new Room
                {
                    ID = Guid.Parse("B7311C51-922B-41C6-8020-90AC7E175B37"),
                    HotelID = HotelId4,
                    RoomTypeID = RoomTypeId2,
                    RoomNumber = "201",
                    Status = "Available",
                    PricePerNight = 600
                },
                 new Room
                 {
                     ID = Guid.Parse("3DDE8654-843B-4DDD-9C75-68236CDD866E"),
                     HotelID = HotelId4,
                     RoomTypeID = RoomTypeId3,
                     RoomNumber = "301",
                     Status = "Available",
                     PricePerNight = 700
                 },
                 new Room
                 {
                     ID = Guid.Parse("EEF3C6F2-C3B4-497F-B838-B9C96B27218F"),
                     HotelID = HotelId4,
                     RoomTypeID = RoomTypeId4,
                     RoomNumber = "401",
                     Status = "Available",
                     PricePerNight = 800
                 }

            );
            base.OnModelCreating(modelBuilder);
        }

    }
}
