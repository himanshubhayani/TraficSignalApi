namespace Test.data.ViewModels
{
    using System;
    using System.Collections.Generic;
    using Test.data.Models;

    public class UserVM : CommonResponse
    {
        public Users User { get; set; }

        public bool Remember { get; set; }
    }

    public class CreatePassword
    {
        public string HashCode { get; set; }

        public string NewPassword { get; set; }

        public string NewPasswordRepeat { get; set; }
    }

    public class ResetPassword
    {
        public string Email { get; set; }

        public bool UserExist { get; set; } = false;
    }

    public class ChangePassword
    {
        public int UserId { get; set; }

        public string OldPassword { get; set; }

        public string NewPassword { get; set; }

        public string RepetPassword { get; set; }

        public bool IsPasswordMatch { get; set; }
    }

    public class CommonResponse
    {
        public bool IsValid { get; set; }

        public string Message { get; set; }
    }


    public class UsersFilter
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int PageSize { get; set; }

        public int PageNum { get; set; }

        public string IsActive { get; set; }

        public string OrderColumnName { get; set; }

        public string OrderColumnDir { get; set; }
    }

    public class UsersResult
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ProfilePic { get; set; }

        public bool IsActive { get; set; }

        public int TotalRecords { get; set; }
    }

    public class TokenVM
    {
        public string Token { get; set; }

        public string RefreshToken { get; set; }
    }
}