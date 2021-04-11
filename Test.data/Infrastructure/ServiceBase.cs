using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Test.data
{

    public class ServiceBase<T> where T : class
    {
        protected TestContext dbContext;
        private readonly IUnitOfWork unitOfWork;

        public ServiceBase(IDbFactory dbFactory, IUnitOfWork unitOfWork)
        {
            dbContext = dbFactory.Init();
            this.unitOfWork = unitOfWork;
        }

        public async Task<IQueryable<T>> GetAllAsync()
        {
            var result = dbContext.Set<T>();
            return result;
        }

        public List<T> FindAll(Expression<Func<T, bool>> match)
        {
            return dbContext.Set<T>().Where(match).ToList();
        }

        public async Task<IQueryable<T>> FindAllAsync(Expression<Func<T, bool>> match)
        {
            return dbContext.Set<T>().Where(match);
        }

        public async Task<T> GetAsync(int id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }

        public T Add(T t)
        {
            dbContext.Set<T>().Add(t);
            return t;
        }

        public List<T> AddRange(List<T> t)
        {
            dbContext.Set<T>().AddRange(t);
            return t;
        }

        public async Task<T> UpdateAsync(T updated, int key)
        {
            if (updated == null)
                return null;

            T existing = await dbContext.Set<T>().FindAsync(key);
            if (existing != null)
            {
                dbContext.Entry(existing).CurrentValues.SetValues(updated);
            }
            dbContext.SaveChanges();
            return existing;
        }

        public T Update(T updated, int key)
        {
            if (updated == null)
                return null;

            T existing = dbContext.Set<T>().Find(key);
            if (existing != null)
            {
                dbContext.Entry(existing).CurrentValues.SetValues(updated);
            }
            return existing;
        }

        public void Delete(T t)
        {
            dbContext.Set<T>().Remove(t);
            dbContext.SaveChanges();
        }


        public async Task<T> UpdateAsync(T updated, String key)
        {
            if (updated == null)
                return null;

            T existing = await dbContext.Set<T>().FindAsync(key);
            if (existing != null)
            {
                dbContext.Entry(existing).CurrentValues.SetValues(updated);
            }
            return existing;
        }

        public async Task<T> GetAsync(String id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }

        public async Task SaveAsync()
        {
            await dbContext.SaveChangesAsync();
        }

        public void Save()
        {
            dbContext.SaveChanges();
            unitOfWork.Commit();
        }

        public void BeginTransaction()
        {
            unitOfWork.BeginTransaction();
        }

        public void Rollback()
        {
            unitOfWork.Rollback();
        }

        public async Task Commit()
        {
            await unitOfWork.Commit();
        }

        public async Task<IQueryable<T>> GetMany(Expression<Func<T, bool>> where)
        {
            return dbContext.Set<T>().Where(where);
        }

        public async Task<IList<T>> GetAllListAsnc()
        {
            IList<T> result = dbContext.Set<T>().ToList();
            return result;
        }

        public List<T> GetAllList()
        {
            List<T> result = dbContext.Set<T>().ToList();
            return result;
        }
    }
}