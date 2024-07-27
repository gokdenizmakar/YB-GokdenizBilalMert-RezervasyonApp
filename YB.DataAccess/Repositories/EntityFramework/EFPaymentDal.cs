using YB.DataAccess.Abstractions;
using YB.DataAccess.Context;
using YB.Entities.Models;

namespace YB.DataAccess.Repositories.EntityFramework
{
    public class EFPaymentDal : EfGenericRepositoryDal<Payment>, IPaymentDal
    {
        public EFPaymentDal(ApplicationDbContext _context) : base(_context)
        {
        }
    }
}
