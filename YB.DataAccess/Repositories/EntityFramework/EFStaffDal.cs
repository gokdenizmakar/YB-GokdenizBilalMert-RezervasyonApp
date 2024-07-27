using YB.DataAccess.Abstractions;
using YB.DataAccess.Context;
using YB.Entities.Models;

namespace YB.DataAccess.Repositories.EntityFramework
{
    public class EFStaffDal : EfGenericRepositoryDal<Staff>, IStaffDal
    {
        public EFStaffDal(ApplicationDbContext _context) : base(_context)
        {
        }
    }
}
