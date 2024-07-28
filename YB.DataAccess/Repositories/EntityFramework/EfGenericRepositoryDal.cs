using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using YB.DataAccess.Abstractions;
using YB.DataAccess.Context;
using YB.Entities.Abstraction;

namespace YB.DataAccess.Repositories.EntityFramework
{
    public class EfGenericRepositoryDal<T> : IRepositoryDal<T> where T : Base, new()
    {
        private readonly ApplicationDbContext context;
        private readonly DbSet<T> dbset;
        public EfGenericRepositoryDal(ApplicationDbContext _context)
        {
            context = _context;
            dbset = context.Set<T>();
        }
        public void Add(T entity)
        {
            dbset.Add(entity);
            context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var entity = Get(x=>x.ID == id);
            entity.IsDeleted = true;
            entity.IsActive = false;
            Update(entity);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return dbset.FirstOrDefault(filter) ?? throw new Exception("Veri bulunamadı!");
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter=null)
        {
            return dbset.Where(filter).ToList() ?? throw new Exception("Veri bulunamadı!");
        }

        public IQueryable<T> GetAllQueryable(Expression<Func<T, bool>> filter = null)
        {
            return filter == null ? dbset : dbset.Where(filter) ?? throw new Exception("Veri bulunamadı!");
        }

        public T GetByID(Guid id)
        {
            return dbset.Find(id) ?? throw new Exception("Veri bulunamadı!");
        }

        public bool IfEntityExists(Expression<Func<T, bool>> filter)
        {
            return dbset.Any(filter);
        }

        public void Update(T entity)
        {
            entity.UpdatedDate = DateTime.Now;
            dbset.Update(entity);
            context.SaveChanges();
        }
    }
}
