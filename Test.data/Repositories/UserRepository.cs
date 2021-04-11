namespace Test.data
{
    using Test.data.Models;

    public partial class UserRepository : RepositoryBase<Users>, IUserRepository
    {
        public UserRepository(IDbFactory _dbFactory) : base(_dbFactory)
        {

        }
    }

    public partial interface IUserRepository : IRepository<Users>
    {
    }
}