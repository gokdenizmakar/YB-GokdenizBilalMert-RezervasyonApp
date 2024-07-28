using FluentValidation;
using FluentValidation.Results;
using System.Linq.Expressions;
using YB.Business.Abstractions;
using YB.Business.Validator;
using YB.DataAccess.Abstractions;
using YB.Entities.Models;

namespace YB.Business.Services
{
    public class StaffService : IStaffService
    {
        private readonly IStaffDal staffdal;
        public StaffService(IStaffDal _staffDal)
        {
            staffdal = _staffDal;
        }
        public void Add(Staff entity)
        {
            StaffValidator hVal = new StaffValidator();
            ValidationResult result = hVal.Validate(entity);
            if (!result.IsValid)
            {
                throw new Exception(string.Join("\n", result.Errors));
            }
            staffdal.Add(entity);
        }

        public void Delete(Guid id)
        {
            if (staffdal.IfEntityExists(x => x.ID == id))
            {
                throw new Exception("Silinecek hotel bulunamadı!");
            }
            staffdal.Delete(id);
        }

        public IEnumerable<Staff> GetAll()
        {
            return staffdal.GetAll().Where(x => x.IsActive == true && x.IsDeleted == false);
        }


        public Staff GetByID(Guid id)
        {
            if (id == default(Guid))
            {
                throw new Exception("Null ID değeri!");
            }
            return staffdal.Get(x=>x.ID==id);
        }

        public bool IfEntityExists(Expression<Func<Staff, bool>> filter)
        {
            if (filter == null)
            {
                throw new Exception("Personel filtresi boş olamaz!(IfEntityExists)");
            }
            return staffdal.IfEntityExists(filter);
        }

        public void Update(Staff entity)
        {
            StaffValidator hVal = new StaffValidator();
            ValidationResult result = hVal.Validate(entity);
            if (!result.IsValid)
            {
                throw new Exception(string.Join("\n", result.Errors));
            }
            staffdal.Update(entity);
        }
    }
}
