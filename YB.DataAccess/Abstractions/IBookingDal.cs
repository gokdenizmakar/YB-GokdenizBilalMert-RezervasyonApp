using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YB.Entities.Models;

namespace YB.DataAccess.Abstractions
{
    public interface IBookingDal : IRepositoryDal<Booking>
    {
        public void AddBookingWithGuests(Booking booking, List<Guid> guestIds);
        public IEnumerable<object> GetRoomByVisible(byte roomCapacity22,DateOnly checkin,DateOnly checkout, Guid hotelid);

        IEnumerable<object> GetAllBookingAllDetail();
    }
}
