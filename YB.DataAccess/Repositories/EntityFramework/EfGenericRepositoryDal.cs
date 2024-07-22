using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
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
              dbset=context.Set<T>();
        }
        public void Add(T entity)
        {
            dbset.Add(entity);
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            entity.IsDeleted = true;
            entity.IsActive = false;
            dbset.Update(entity);
            context.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return dbset.FirstOrDefault(filter) ?? throw new Exception("Veri bulunamadı!");
        }

        public IQueryable<T> GetAll()
        {
            return dbset ?? throw new Exception("Veri bulunamadı!");
        }

        public IQueryable<T> GetAllQueryable(Expression<Func<T, bool>> filter)
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
