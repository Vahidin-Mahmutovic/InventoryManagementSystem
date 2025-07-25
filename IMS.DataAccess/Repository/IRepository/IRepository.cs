﻿using System.Linq.Expressions;

namespace IMS.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(string? includeProperties = null);
        T Get(Expression<Func<T, bool>> filter, string includeProperties = null);
        void Add(T entity);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter, string? includeProperties = null);
    }
}
