using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YB.Business.Abstractions;
using YB.Business.Validator;
using YB.DataAccess.Abstractions;
using YB.DataAccess.Repositories.EntityFramework;
using YB.Entities.Abstraction;
using YB.Entities.Models;

namespace YB.Business.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingDal bookingdal;

        public BookingService(IBookingDal _bookingdal)
        {
            bookingdal = _bookingdal;
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

        public void AddBookingWithGuests(Booking booking, List<Guid> guestIds)
        {
            BookingValidator bVal = new BookingValidator();
            ValidationResult result = bVal.Validate(booking);
            if (!result.IsValid)
            {
                throw new Exception(string.Join("\n", result.Errors));
            }
            if (guestIds == null)
            {
                throw new Exception("Misafir ID'leri boş olamaz!");
            }
            bookingdal.AddBookingWithGuests(booking, guestIds);
        }

        public void Delete(Guid id)
        {
            if (id== default(Guid))
            {
                throw new Exception("Geçersiz ID!");
            }
            bookingdal.Delete(id);
        }

        public Booking Get(Expression<Func<Booking, bool>> filter)
        {
            if (filter == null)
            {
                throw new Exception("Rezervasyon filtresi boş olamaz!(Get)");
            }
            return bookingdal.Get(filter);
        }

        public IEnumerable<Booking> GetAll()
        {
            return bookingdal.GetAll().Where(x => x.IsActive == true && x.IsDeleted == false);
        }

        public IEnumerable<object> GetAllBookingAllDetail()
        {
            return bookingdal.GetAllBookingAllDetail() ?? throw new Exception("Kayıtlı rezervasyon bulunamadı!");
        }





        public IQueryable<Booking> GetAllBookingQueryable(Guid bookingid)
        {
            return bookingdal.GetAllQueryable(x => x.ID == bookingid).Include(x=>x.Guests).Include(x=>x.Room);
        }









        public IQueryable<Booking> GetAllQueryable(Expression<Func<Booking, bool>> filter)
        {
            if (filter == null)
            {
                throw new Exception("Rezervasyon filtresi boş olamaz!(GetAllQueryable)");
            }
            return bookingdal.GetAllQueryable(filter);
        }

        public Booking GetByID(Guid id)
        {
            if (id == default(Guid))
            {
                throw new Exception("Null ID değeri!");
            }
            return bookingdal.GetByID(id);
        }

        public IEnumerable<object> GetRoomByVisible(byte roomCapacity22, DateOnly checkin, DateOnly checkout, Guid hotelid)
        {
            if (hotelid == null) throw new Exception("Lütfen Hotel seçiniz!");

            else if (roomCapacity22 == null) throw new Exception("Lütfen misafir sayısı giriniz!");

            else if (checkout < checkin || checkin==default(DateOnly) || checkout == default(DateOnly) ) throw new Exception("Lütfen rezervasyon başlangıç tarihini, bitiş tarihinden önce olarak seçiniz!");

            return bookingdal.GetRoomByVisible(roomCapacity22, checkin, checkout, hotelid) ?? throw new Exception("Geçerli filtrede oda bulunamadı! Lütfen hotel, tarih veya misafir sayısını değiştiriniz!");
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

        public void UpdateBookingWithGuests(Booking updatedBooking)
        {
            BookingValidator bVal = new BookingValidator();
            ValidationResult result = bVal.Validate(updatedBooking);
            if (!result.IsValid)
            {
                throw new Exception(string.Join("\n", result.Errors));
            }

            bookingdal.UpdateBookingWithGuests(updatedBooking);
        }
    }
}
