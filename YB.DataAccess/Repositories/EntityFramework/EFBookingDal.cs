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

        public IEnumerable<Room> GetRoomByVisible(Booking booking, List<Guid> guestIds)
        {
            return context.Rooms.Include(x=>x.Bookings).Where()
        }
    }
}
