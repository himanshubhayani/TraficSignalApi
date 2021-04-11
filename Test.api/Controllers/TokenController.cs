using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Test.data;
using Test.data.Models;
using Test.logic.Common;

namespace Test.api.Controllers
{

    [AllowAnonymous]
    [Route("api/[controller]")]
    public class TokenController : Controller
    {

        private string email = "";
        private int userId = 0;

        private readonly TestContext _context;
        private readonly JsonSerializerSettings _serializerSettings;
        private readonly ITokenService _tokenService;
        public TokenController(TestContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
            _serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };
        }

        [HttpPost]
        public async Task Authenticate([FromBody] Users Model)
        {
            try
            {
                var existingUser = _context.Users.Where(m => m.Email.Trim().ToLower() == Model.Email.Trim().ToLower() && m.Password == Model.Password).FirstOrDefault();

                // If user not found
                if (existingUser == null)
                {
                    Response.StatusCode = 401;
                    var InValidResponse = new
                    {
                        statusCode = 401,
                        errorCode = "1",
                        errorCase = "invalid credential",
                    };
                    Response.ContentType = "application/json";
                    await Response.WriteAsync(JsonConvert.SerializeObject(InValidResponse, _serializerSettings));
                    return;
                }

                // If user is inactive or deleted
                if (existingUser.IsActive == false)
                {
                    Response.StatusCode = 401;
                    var EmailNotVerifiedResponse = new
                    {
                        statusCode = 401,
                        errorCode = "4",
                        errorCase = "Either user is inactive or deleted.",
                    };
                    Response.ContentType = "application/json";
                    await Response.WriteAsync(JsonConvert.SerializeObject(EmailNotVerifiedResponse, _serializerSettings));
                    return;
                }
                this.email = existingUser.Email;
                this.userId = existingUser.Id;

                string exp = CommonMinutes.DefaultExpiryMinutes;
                var token = helper.Utility.GenerateToken(GetClaim(), exp);
                var refreshToken = helper.Utility.GenerateRefreshToken();

                // Insert refresh token 
                Tokens objtoken = new Tokens();
                objtoken.UserId = existingUser.Id;
                objtoken.Token = refreshToken;
                objtoken.CretedDate = DateTime.UtcNow.Date;

                var oldToken = _tokenService.GetTokenByUserId(objtoken.UserId);
                if (oldToken != null)
                {
                    await _tokenService.RemoveTokenAsync(oldToken);
                    await _tokenService.InsertTokenAsync(objtoken);
                }
                else
                {
                    await _tokenService.InsertTokenAsync(objtoken);
                }

                var response = new
                {
                    access_token = token,
                    refresh_Token = refreshToken,
                    model = existingUser
                };

                Response.ContentType = "application/json";
                await Response.WriteAsync(JsonConvert.SerializeObject(response, _serializerSettings));

            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                var EmailNotVerifiedResponse = new
                {
                    statusCode = 400,
                    errorCode = "4",
                    errorCase = "An error occurred while processing your request.",
                };
                Response.ContentType = "application/json";
                await Response.WriteAsync(JsonConvert.SerializeObject(EmailNotVerifiedResponse, _serializerSettings));
                return;
            }
        }

        [HttpPost("LogOut")]
        public async Task LogOut([FromBody] int userId)
        {

        }
        #region Helper

        private Dictionary<string, string> GetClaim()
        {
            var claim = new Dictionary<string, string>();
            claim.Add("Sid", userId.ToString());
            return claim;
        }

        #endregion
    }
}