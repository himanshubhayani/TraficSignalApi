namespace Test.data
{
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using Test.data.Models;
    using System.Linq;
    using Test.data.ViewModels;
    using System;
    using System.Threading.Tasks;
    using System.Data;

    public partial class UserService : ServiceBase<Users>, IUserService
    {
        private readonly IUnitOfWork _uow;
        public UserService(IDbFactory dbFactory, IUnitOfWork unitOfWork) : base(dbFactory, unitOfWork)
        {
            _uow = unitOfWork;
        }


    }

    public partial interface IUserService : IService<Users>
    {
       
    }
}