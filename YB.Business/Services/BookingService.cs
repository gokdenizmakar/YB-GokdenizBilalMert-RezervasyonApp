using FluentValidation;
using FluentValidation.Results;
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
            bookingdal= _bookingdal;
        }
        public void Add(Booking entity)
        {
            //BookingValidator bVal = new BookingValidator();
            //ValidationResult result = bVal.Validate(entity);
            //if (!result.IsValid)
            //{
            //    throw new Exception(string.Join("\n", result.Errors));
            //}
            //bookingdal.Add(entity);
        }

        public void AddBookingWithGuests(Booking booking, List<Guid> guestIds)
        {
            BookingValidator bVal = new BookingValidator();
            ValidationResult result = bVal.Validate(booking);
            if (!result.IsValid)
            {
                throw new Exception(string.Join("\n", result.Errors));
            }
            if (guestIds==null)
            {
                throw new Exception("Misafir ID'leri boş olamaz!");
            }
            bookingdal.AddBookingWithGuests(booking, guestIds);
        }

        public void Delete(Booking entity)
        {
            if (bookingdal.IfEntityExists(b => b.ID == entity.ID))
            {
                throw new Exception("Silinecek rezervasyon bulunamadı!");
            }
            bookingdal.Delete(entity);
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
    }
}
