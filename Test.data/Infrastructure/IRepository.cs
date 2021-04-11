namespace Test.data
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using System.Data;
    using Test.data.Models;

    public interface IRepository<T> where T : class
    {
        T Add(T entity);

        Task<T> AddAsync(T entity);

        Task<List<T>> AddRangeAsync(List<T> t);

        T Update(T entity, int Key);

        Task<T> UpdateAsync(T entity, int key);

        void Delete(T entity);

        Task<int> DeleteAsync(T entity);

        int Count();

        Task<int> CountAsync();

        int Delete(Expression<Func<T, bool>> where);

        Task<int> DeleteAsync(Expression<Func<T, bool>> where);

        ICollection<T> GetAll();

        List<T> GetAllList();

        Task<IQueryable<T>> GetAllAsync();

        Task<List<T>> GetAllAsyncList();

        T Get(int id);

        Task<T> GetAsync(int id);

        T Find(Expression<Func<T, bool>> match);

        Task<T> FindAsync(Expression<Func<T, bool>> match);

        ICollection<T> FindAll(Expression<Func<T, bool>> match);

        Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match);

        Task<IEnumerable<T>> ExecuteSPAsync<T>(string query, params SqlParameter[] SqlPrms) where T : new();
        Task<List<T>> ExecuteSPAsyncList<T>(string query, params SqlParameter[] SqlPrms) where T : new();

        IEnumerable<T> ExecuteSP<T>(string query, params SqlParameter[] SqlPrms) where T : new();

        DataTableCollection ExecuteSPForMultipleTableReturn<T>(string query, params SqlParameter[] SqlPrms) where T : new();

        object ExecuteStoreProcedure(string query, params SqlParameter[] sqlParameters);
        Task ExecuteStoreProcedureAsync(string query, params SqlParameter[] sqlParameters);

        void Truncate(String TableName);

        Task TruncateAsync(String TableName);

        Task<IQueryable<T>> GetMany(Expression<Func<T, bool>> where);
        Task<List<T>> GetManyAsync(Expression<Func<T, bool>> where);
    }
}