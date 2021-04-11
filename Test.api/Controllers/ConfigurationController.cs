using System;
using System.Linq;
using Test.data.ViewModels;
using Test.data;
using Test.data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Test.logic.Common;
using Microsoft.AspNetCore.Hosting;
using Test.logic;
using System.Threading.Tasks;
using System.IO;
using Test.helper;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Test.api.Controllers
{
    [Produces("application/json")]
    [Route("api/Configuration")]
    public class ConfigurationController : Controller
    {
        #region 'Constructor'
        private readonly IConfigurationService _iConfigService;
        MessageVM messageVM = new MessageVM();
        public ConfigurationController(IConfigurationService iConfigService)
        {
            _iConfigService = iConfigService;
        }
        #endregion
        #region 'ger Function'

        /// <summary>
        /// This API called when user create post.
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetConfigByUserId")]
        public async Task<OperationResult<GlobalConfiguration>> GetConfigByUserId([FromBody] int UserId)
        {
            try
            {
                var result = await _iConfigService.GetConfigurationByUserId(UserId);
                return new OperationResult<GlobalConfiguration>(true, messageVM, result);
            }
            catch (Exception ex)
            {
                return new OperationResult<GlobalConfiguration>(messageVM, false);
            }
        }
        #endregion
        #region 'Set Function'

        /// <summary>
        /// This API called when user create post.
        /// </summary>
        /// <returns></returns>
        [HttpPost("SaveConfig")]
        public async Task<OperationResult> SaveConfig([FromBody] GlobalConfiguration model)
        {
            try
            {
                if (model.UserId != null)
                {
                    var result = await _iConfigService.InsertUpdateConfig(model);
                    return new OperationResult(true, CommonMessage.SuccessMsg);
                }
                else
                {
                    return new OperationResult(false, CommonMessage.DefaultErrorMessage);
                }
            }
            catch (Exception ex)
            {
                return new OperationResult(false, CommonMessage.DefaultErrorMessage);
            }
        }
        #endregion

    }
}