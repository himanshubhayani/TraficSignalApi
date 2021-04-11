using Test.data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test.data
{
    public partial class TokenRepository : RepositoryBase<Tokens>, ITokenRepository
    {
        public TokenRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }

    public partial interface ITokenRepository : IRepository<Tokens>
    {

    }
}
