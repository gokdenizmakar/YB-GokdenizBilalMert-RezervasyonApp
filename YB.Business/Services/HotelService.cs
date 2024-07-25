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
using YB.Entities.Models;

namespace YB.Business.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelDal hoteldal;
        public HotelService(IHotelDal _hoteldal)
        {
            hoteldal = _hoteldal;
        }
        public void Add(Hotel entity)
        {
            HotelValidator hVal= new HotelValidator();
            ValidationResult result = hVal.Validate(entity);
            if (!result.IsValid)
            {
                throw new Exception(string.Join("\n", result.Errors));
            }
            hoteldal.Add(entity);
        }

        public void Delete(Guid id)
        {
            if (hoteldal.IfEntityExists(x=>x.ID==id))
            {
                throw new Exception("Silinecek hotel bulunamadı!");
            }
            hoteldal.Delete(id);
        }

        public Hotel Get(Expression<Func<Hotel, bool>> filter)
        {
            if (filter == null)
            {
                throw new Exception("Hotel filtresi boş olamaz!(Get)");
            }
            return hoteldal.Get(filter);
        }

        public IEnumerable<Hotel> GetAll()
        {
            return hoteldal.GetAll().Where(x=>x.IsActive==true && x.IsDeleted==false);
        }

        public IQueryable<Hotel> GetAllQueryable(Expression<Func<Hotel, bool>> filter)
        {
            //if (filter == null)
            //{
            //    throw new Exception("Hotel filtresi boş olamaz!(GetAllQueryable)");
            //}
            //return hoteldal.GetAllQueryable(filter);

            return hoteldal.GetAllQueryable(x => x.IsActive == true);
        }

        public Hotel GetByID(Guid id)
        {
            if (id == default(Guid))
            {
                throw new Exception("Null ID değeri!");
            }
            return hoteldal.GetByID(id);
        }

        public bool IfEntityExists(Expression<Func<Hotel, bool>> filter)
        {
            if (filter == null)
            {
                throw new Exception("Hotel filtresi boş olamaz!(IfEntityExists)");
            }
            return hoteldal.IfEntityExists(filter);
        }

        public void Update(Hotel entity)
        {
            HotelValidator hVal = new HotelValidator();
            ValidationResult result = hVal.Validate(entity);
            if (!result.IsValid)
            {
                throw new Exception(string.Join("\n", result.Errors));
            }

            hoteldal.Update(entity);
        }
    }
}
