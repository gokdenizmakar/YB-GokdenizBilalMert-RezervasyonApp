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
using YB.Entities.Models;

namespace YB.Business.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentDal paymentdal;
        public PaymentService(IPaymentDal _paymentdal)
        {
            paymentdal = _paymentdal;
        }
        public void Add(Payment entity)
        {
            PaymentValidator pVal = new PaymentValidator();
            ValidationResult result = pVal.Validate(entity);
            if (result != null)
            {
                throw new Exception(string.Join("\n", result.Errors));
            }
            paymentdal.Add(entity);
        }

        public void Delete(Payment entity)
        {
            if (paymentdal.IfEntityExists(x => x.ID == entity.ID))
            {
                throw new Exception("Silinecek ödeme bulunamadı!");
            }
            paymentdal.Delete(entity);
        }

        public Payment Get(Expression<Func<Payment, bool>> filter)
        {
            if (filter == null)
            {
                throw new Exception("Ödeme filtresi boş olamaz!(Get)");
            }
            return paymentdal.Get(filter);
        }

        public IQueryable<Payment> GetAll()
        {
            return paymentdal.GetAll().Where(x => x.IsActive == true && x.IsDeleted == false);
        }

        public IQueryable<Payment> GetAllQueryable(Expression<Func<Payment, bool>> filter)
        {
            if (filter == null)
            {
                throw new Exception("Ödeme filtresi boş olamaz!(GetAllQueryable)");
            }
            return paymentdal.GetAllQueryable(filter);
        }

        public Payment GetByID(Guid id)
        {
            if (id == default(Guid))
            {
                throw new Exception("Null ID değeri!");
            }
            return paymentdal.GetByID(id);
        }

        public bool IfEntityExists(Expression<Func<Payment, bool>> filter)
        {
            if (filter == null)
            {
                throw new Exception("Ödeme filtresi boş olamaz!(IfEntityExists)");
            }
            return paymentdal.IfEntityExists(filter);
        }

        public void Update(Payment entity)
        {
            PaymentValidator pVal = new PaymentValidator();
            ValidationResult result = pVal.Validate(entity);
            if (result != null)
            {
                throw new Exception(string.Join("\n", result.Errors));
            }
            paymentdal.Update(entity);
        }
    }
}
