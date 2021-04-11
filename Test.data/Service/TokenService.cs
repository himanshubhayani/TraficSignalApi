using Test.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.data
{
    public partial class TokenService : ServiceBase<Tokens>, ITokenService
    {
         private readonly IUnitOfWork _uow;
        public TokenService(IDbFactory dbFactory, IUnitOfWork unitOfWork) : base(dbFactory, unitOfWork)
        {
             _uow = unitOfWork;
        }

        public Tokens GetTokenByUserId(int userId)
        {
            return _uow.TokenRepository.GetManyAsync(t => t.UserId == userId).Result.FirstOrDefault();
        }

        public async Task<Tokens> InsertTokenAsync(Tokens tokens)
        {
            var newItem = await _uow.TokenRepository.AddAsync(tokens);
            return newItem;
        }

        public async Task RemoveTokenAsync(Tokens token)
        {
            // Delete(token);
            await _uow.TokenRepository.DeleteAsync(token);
        }
    }

    public partial interface ITokenService : IService<Tokens>
    {
        Tokens GetTokenByUserId(int userId);

        Task<Tokens> InsertTokenAsync(Tokens tokens);

        Task RemoveTokenAsync(Tokens token);
    }
}
