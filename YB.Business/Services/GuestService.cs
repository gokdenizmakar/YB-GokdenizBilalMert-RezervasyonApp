﻿using FluentValidation;
using FluentValidation.Results;
using System.Linq.Expressions;
using YB.Business.Abstractions;
using YB.Business.Validator;
using YB.DataAccess.Abstractions;
using YB.Entities.Models;

namespace YB.Business.Services
{
    public class GuestService : IGuestService
    {
        private readonly IGuestDal guestdal;

        public GuestService(IGuestDal _guestdal)
        {
            guestdal = _guestdal;

        }
        public void Add(Guest entity)
        {
            GuestValidator gVal = new GuestValidator();
            ValidationResult result = gVal.Validate(entity);
            if (!result.IsValid)
            {
                throw new Exception(string.Join("\n", result.Errors));
            }
            guestdal.Add(entity);
        }

        public void Delete(Guid id)
        {
            if (guestdal.IfEntityExists(g => g.ID == id))
            {
                throw new Exception("Silinecek misafir bulunamadı!");
            }
            guestdal.Delete(id);
        }

        public IEnumerable<Guest> GetAll()
        {
            return guestdal.GetAll().Where(x => x.IsActive == true && x.IsDeleted == false);
        }


        public Guest GetByID(Guid id)
        {
            if (id == default(Guid))
            {
                throw new Exception("Null ID değeri!");
            }
            return guestdal.Get(x=>x.ID==id);
        }

        public bool IfEntityExists(Expression<Func<Guest, bool>> filter)
        {
            if (filter == null)
            {
                throw new Exception("Misafir filtresi boş olamaz!(IfEntityExists)");
            }
            return guestdal.IfEntityExists(filter);
        }

        public void Update(Guest entity)
        {
            GuestValidator gVal = new GuestValidator();
            ValidationResult result = gVal.Validate(entity);
            if (!result.IsValid)
            {
                throw new Exception(string.Join("\n", result.Errors));
            }

            guestdal.Update(entity);
        }
    }
}
