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
        public UserController()
        {
           
        }
        #endregion

       
    }
}