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
    [Route("api/User")]
    public class UserController : Controller
    {
        #region 'Constructor'
        private readonly IUserService _userService;
        MessageVM messageVM = new MessageVM();
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        #endregion

        /// <summary>
        /// This API called when user register.
        /// </summary>
        /// <param name="Model"> User Model</param>
        /// <returns></returns>
        [HttpPost("CreateUser")]
        public async Task<OperationResult<Users>> CreateUser([FromBody] Users Model)
        {
            try
            {
                var result = await _userService.CheckInsertOrUpdateAsync(Model);
                return new OperationResult<Users>(result);
            }

            catch (Exception ex)
            {
                messageVM.MessageType = Convert.ToInt32(MessageType.Error);
                messageVM.Message = CommonMessage.DefaultErrorMessage;
                return new OperationResult<Users>(messageVM, false);
            }
        }

        /// <summary>
        /// This API called for Get all active user.
        /// </summary>
        /// <param name="Model"> User Model</param>
        /// <returns></returns>
        [HttpGet("GetAllUser")]
        public async Task<OperationResult<List<Users>>> GetAllActiveUser()
        {
            try
            {
                var result = await _userService.GetAllActiveUser();
                return new OperationResult<List<Users>>(result);
            }

            catch (Exception ex)
            {
                messageVM.MessageType = Convert.ToInt32(MessageType.Error);
                messageVM.Message = CommonMessage.DefaultErrorMessage;
                return new OperationResult<List<Users>>(messageVM, false);
            }
        }
    }
}