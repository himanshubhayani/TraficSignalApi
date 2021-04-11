using Test.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.data
{
    public partial class ConfigurationService : ServiceBase<GlobalConfiguration>, IConfigurationService
    {
        private readonly IUnitOfWork _uow;
        public ConfigurationService(IDbFactory dbFactory, IUnitOfWork unitOfWork) : base(dbFactory, unitOfWork)
        {
            _uow = unitOfWork;
        }

        public async Task<GlobalConfiguration> GetConfigurationByUserId(int userId)
        {
            return _uow.ConfigurationRepository.GetManyAsync(t => t.UserId == userId).Result.FirstOrDefault();
        }

        public async Task<GlobalConfiguration> InsertUpdateConfig(GlobalConfiguration model)
        {
            var userConfigData = _uow.ConfigurationRepository.GetManyAsync(i => i.UserId == model.UserId).Result.FirstOrDefault();
            if (userConfigData != null)
            {
                userConfigData.UserId=model.UserId;
                userConfigData.Direction=model.Direction;
                userConfigData.TimeInterval=model.TimeInterval;
                await _uow.ConfigurationRepository.UpdateAsync(userConfigData, userConfigData.Id);
            }
            else{
                var newItem = await _uow.ConfigurationRepository.AddAsync(model);
                return newItem;
            }
           return model;
        }

    }

    public partial interface IConfigurationService : IService<GlobalConfiguration>
    {
        Task<GlobalConfiguration> GetConfigurationByUserId(int userId);

        Task<GlobalConfiguration> InsertUpdateConfig(GlobalConfiguration model);
    }
}
