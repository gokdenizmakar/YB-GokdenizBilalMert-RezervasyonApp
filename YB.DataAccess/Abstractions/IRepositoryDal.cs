using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YB.Entities.Abstraction;

namespace YB.DataAccess.Abstractions
{
    public interface IRepositoryDal<T> where T : IEntity,new()
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(Guid id);
        T GetByID(Guid id);
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T, bool>> filter);
        IQueryable<T> GetAllQueryable(Expression<Func<T, bool>> filter);
        bool IfEntityExists(Expression<Func<T, bool>> filter);

    }
}
