
using System;
using System.Collections.Generic;
namespace Test.data
{
    public class DbFactory : Disposable, IDbFactory
    {
        TestContext dbContext;

        public TestContext Init(){          
            return dbContext ?? (dbContext = new TestContext());
        }

        protected override void DisposeCore(){
            if(dbContext != null){
                dbContext.Dispose();
            }
        }
      
    }
}