using System;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace Test.logic
{
    public class CommonFunction
    {
        #region Property Initialization
       
        #endregion

        #region Constructor
        public CommonFunction()
        {
          
        }
        #endregion

        #region Get Function
        public static int GetLoggedInUserId(ClaimsPrincipal user)
        {
            var userId = Convert.ToInt32(user.FindFirst(JwtRegisteredClaimNames.Sid).Value);
            return userId;
        }
        public static int GenerateRandomNo()
        {
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }
        #endregion

        #region Set Functions

        #endregion

        #region Private Functions

        #endregion
    }
}
