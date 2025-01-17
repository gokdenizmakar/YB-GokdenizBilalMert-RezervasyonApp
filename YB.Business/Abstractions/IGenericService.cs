﻿using System.Linq.Expressions;
using YB.Entities.Abstraction;

namespace YB.Business.Abstractions
{
    public interface IGenericService<T> where T : IEntity, new()
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(Guid id);
        T GetByID(Guid id);
        IEnumerable<T> GetAll();
        bool IfEntityExists(Expression<Func<T, bool>> filter);
    }
}
