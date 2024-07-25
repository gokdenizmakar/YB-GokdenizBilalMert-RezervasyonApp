using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YB.DataAccess.Abstractions;
using YB.DataAccess.Context;
using YB.Entities.Models;

namespace YB.DataAccess.Repositories.EntityFramework
{
    public class EFBookingDal : EfGenericRepositoryDal<Booking>, IBookingDal
    {
        private readonly ApplicationDbContext context;
        public EFBookingDal(ApplicationDbContext _context) : base(_context)
        {
            context = _context;
        }

        public void AddBookingWithGuests(Booking booking, List<Guid> guestIds)
        {
            var guests = context.Guests.Where(g => guestIds.Contains(g.ID)).ToList();
            booking.Guests = guests;
            context.Bookings.Add(booking);
            context.SaveChanges();
        }

        public IEnumerable<object> GetAllBookingAllDetail()
        {
            return context.Bookings.Where(x=>x.IsActive==true && x.IsDeleted== false).Join(context.Rooms,
                      booking => booking.RoomID,
                      room => room.ID,
                      (booking, room) => new { booking, room }).Select(booking=>new 
                      {
                          BookingID=booking.booking.ID,
                          CheckIn=booking.booking.CheckinDate,
                          CheckOut=booking.booking.CheckoutDate,
                          RoomID=booking.booking.RoomID,
                          RoomNumber=booking.booking.Room.RoomNumber,
                          TotalPrice=booking.booking.TotalPrice,
                         Guests=booking.booking.Guests
                      }).ToList(); 
        }

        public IEnumerable<object> GetRoomByVisible(byte roomCapacity22, DateOnly checkin, DateOnly checkout, Guid hotelid)
        {
            // booking, room, roomtype ilişkili data çekildi.
            var list = context.Bookings
                .Join(context.Rooms,
                      booking => booking.RoomID,
                      room => room.ID,
                      (booking, room) => new { booking, room })
                .Join(context.RoomTypes,
                      br => br.room.RoomTypeID,
                      roomType => roomType.ID,
                      (br, roomType) => new { br.booking, br.room, roomType })
                .ToList();

            var eslesenler = list.Where(x => x.booking.Room.HotelID == hotelid
                                          && x.booking.CheckinDate <= checkout
                                          && x.booking.CheckoutDate >= checkin);

            var idList = eslesenler.Select(x => x.room.ID);

            return context.Rooms
                .Join(context.RoomTypes,
                      room => room.RoomTypeID,
                      roomType => roomType.ID,
                      (room, roomType) => new { room, roomType })
                .Where(x =>x.room.HotelID==hotelid && !idList.Contains(x.room.ID) && x.roomType.Capacity >= roomCapacity22).Select(room => new
                {
                    RoomTypeID = room.roomType.ID,
                    Name = room.roomType.Name,
                    RoomID = room.room.ID,
                    RoomNumber=room.room.RoomNumber,
                    Price=room.room.PricePerNight
                })
                .ToList();
        }
    }
}
