using YB.Entities.Models;

namespace YB.Business.Abstractions
{
    public interface IBookingService : IGenericService<Booking>
    {
        public IEnumerable<object> GetRoomByVisible(byte roomCapacity22, DateOnly checkin, DateOnly checkout, Guid hotelid);
        IEnumerable<object> GetAllBookingAllDetail();
        //IEnumerable<object> GetAllBookingAndGuest();

        IQueryable<Booking> GetAllBookingQueryable(Guid bookingid);

        public void UpdateBookingWithGuests(Booking updatedBooking, List<Guest> deleteguestlist);
    }
}
