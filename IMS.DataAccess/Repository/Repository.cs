﻿using IMS.DataAccess.Data;
using IMS.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace IMS.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext db) { 
            _db = db;
            this.dbSet = _db.Set<T>();
        }

        public void Add(T entity)
        {
           dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
           dbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
           IQueryable<T> query = dbSet;
            return query.ToList();
        }
    }
}
