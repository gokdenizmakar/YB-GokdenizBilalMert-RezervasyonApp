using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using YB.Business.Abstractions;
using YB.Business.Validator;
using YB.DataAccess.Abstractions;
using YB.Entities.Models;

namespace YB.Business.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingDal bookingdal;
        private IGuestService guestService;

        public BookingService(IBookingDal _bookingdal, IGuestService _guestService)
        {
            bookingdal = _bookingdal;
            guestService = _guestService;
        }
        public void Add(Booking entity)
        {
            BookingValidator bVal = new BookingValidator();
            ValidationResult result = bVal.Validate(entity);
            if (!result.IsValid)
            {
                throw new Exception(string.Join("\n", result.Errors));
            }
            var guestList = entity.Guests.ToList();

            guestList.ForEach(guest =>
            {
                GuestValidator gVal = new GuestValidator();
                ValidationResult result = gVal.Validate(guest);
                if (!result.IsValid)
                {
                    throw new Exception(string.Join("\n", result.Errors));
                }
            });
            bookingdal.Add(entity);
        }

        public void Delete(Guid id)
        {
            if (id == default(Guid))
            {
                throw new Exception("Geçersiz ID!");
            }
            bookingdal.Delete(id);
        }


        public IEnumerable<Booking> GetAll()
        {
            return bookingdal.GetAll().Where(x => x.IsActive == true && x.IsDeleted == false);
        }

        public Booking GetByID(Guid id)
        {
            if (id == default(Guid))
            {
                throw new Exception("Null ID değeri!");
            }
            return bookingdal.Get(x => x.ID == id);
        }
        public bool IfEntityExists(Expression<Func<Booking, bool>> filter)
        {
            if (filter == null)
            {
                throw new Exception("Rezervasyon filtresi boş olamaz!(IfEntityExists)");
            }
            return bookingdal.IfEntityExists(filter);
        }

        public void Update(Booking entity)
        {
            BookingValidator bVal = new BookingValidator();
            ValidationResult result = bVal.Validate(entity);
            if (!result.IsValid)
            {
                throw new Exception(string.Join("\n", result.Errors));
            }

            bookingdal.Update(entity);
        }

        public IEnumerable<object> GetAllBookingAllDetail()
        {
            return bookingdal.GetAllBookingAllDetail() ?? throw new Exception("Kayıtlı rezervasyon bulunamadı!");
        }





        public IQueryable<Booking> GetAllBookingQueryable(Guid bookingid)
        {
            return bookingdal.GetAllQueryable(x => x.ID == bookingid).Include(x => x.Guests).Include(x => x.Room);
        }

        public IEnumerable<object> GetRoomByVisible(byte roomCapacity22, DateOnly checkin, DateOnly checkout, Guid hotelid)
        {
            if (hotelid == null) throw new Exception("Lütfen Hotel seçiniz!");

            else if (roomCapacity22 == null) throw new Exception("Lütfen misafir sayısı giriniz!");

            else if (checkout < checkin || checkin == default(DateOnly) || checkout == default(DateOnly)) throw new Exception("Lütfen rezervasyon başlangıç tarihini, bitiş tarihinden önce olarak seçiniz!");

            return bookingdal.GetRoomByVisible(roomCapacity22, checkin, checkout, hotelid) ?? throw new Exception("Geçerli filtrede oda bulunamadı! Lütfen hotel, tarih veya misafir sayısını değiştiriniz!");
        }


        public void UpdateBookingWithGuests(Booking updatedBooking, List<Guest> deleteguestlist)
        {
            BookingValidator bVal = new BookingValidator();
            ValidationResult result = bVal.Validate(updatedBooking);
            if (!result.IsValid)
            {
                throw new Exception(string.Join("\n", result.Errors));
            }
            deleteguestlist.ForEach(guest =>
            {
                GuestValidator gVal = new GuestValidator();
                ValidationResult result = gVal.Validate(guest);
                if (!result.IsValid)
                {
                    throw new Exception(string.Join("\n", result.Errors));
                }
            });

            //var model = bookingdal.Get(x => x.ID == updatedBooking.ID);
            //List<Guest> eklenecekGuestler = updatedBooking.Guests.ToList();

            ////model.Guests.Contains(x=>deleteguestlist.ForEach(y=>y.ID)) Clear();

            //foreach (var item in deleteguestlist)
            //{
            //    if (!eklenecekGuestler.Contains(item))
            //    {
            //        guestService.Delete(item.ID);
            //        deleteguestlist.Remove(item);
            //    }
            //    else
            //    {
            //        Guest upGuest = eklenecekGuestler.FirstOrDefault(x => x.ID == item.ID);

            //        GuestValidator gVal = new GuestValidator();
            //        ValidationResult upresult = gVal.Validate(upGuest);
            //        if (!upresult.IsValid)
            //        {
            //            throw new Exception(string.Join("\n", result.Errors));
            //        }

            //        upGuest.TC = item.TC;
            //        upGuest.Address = item.Address;
            //        upGuest.FirstName = item.FirstName;
            //        upGuest.LastName = item.LastName;
            //        upGuest.DateOfBirth = item.DateOfBirth;
            //        upGuest.Email = item.Email;
            //        upGuest.Bookings.Clear();

            //        upGuest.Bookings.Add(updatedBooking);
            //        guestService.Update(upGuest);
            //    }
            //}
            //List<Booking> denek2131 = new List<Booking>();
            //denek2131.Add(model);


            deleteguestlist.ForEach(x => guestService.Delete(x.ID));

            bookingdal.UpdateBookingWithGuests(updatedBooking, deleteguestlist);
        }
    }
}
