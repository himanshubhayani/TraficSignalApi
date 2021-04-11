using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Test.data.Models;

namespace Test.data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private TestContext dbContext;
        private IDbContextTransaction _transaction;

        #region Repository Variables

        public IRepository<Users> UserRepository => new RepositoryBase<Users>(dbFactory);
        public IRepository<Tokens> TokenRepository => new RepositoryBase<Tokens>(dbFactory);
        public IRepository<GlobalConfiguration> ConfigurationRepository => new RepositoryBase<GlobalConfiguration>(dbFactory);

        #endregion

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public TestContext DbContext
        {
            get { return dbContext ?? (dbContext = dbFactory.Init()); }
        }

        public void BeginTransaction()
        {
            _transaction = DbContext.Database.BeginTransaction();
        }

        public void Rollback()
        {
            if (_transaction != null)
                _transaction.Rollback();
        }

        public async Task SaveChanges()
        {
            await DbContext.SaveChangesAsync();
        }

        public async Task Commit()
        {
            await DbContext.SaveChangesAsync();
            if (_transaction != null)
                _transaction.Commit();
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
        // public void RejectChanges()
        // {
        //     foreach (var entry in DbContext.ChangeTracker.Entries().Where(e => e.State != EntityState.Unchanged))
        //     {
        //         switch (entry.State)
        //         {
        //             case EntityState.Added:
        //                 entry.State = EntityState.Detached;
        //                 break;
        //             case EntityState.Modified:
        //             case EntityState.Deleted:
        //                 entry.Reload();
        //                 break;
        //         }
        //     }
        // }
    }
}