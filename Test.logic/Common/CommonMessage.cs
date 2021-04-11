using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Threading.Tasks;

namespace Test.logic.Common
{
    public static class CommonMessage
    {
        public static string CurrentURL { get; set; }
        public static string AppURL { get; set; }
        public static string DefaultErrorMessage { get; set; } = "An error occurred while processing your request.";
        public static string EmailExist { get; set; } = "Email already exist!";
        public static string SignupMsg { get; set; } = "Thanks for signing up. Please check your email for verification link and login credentials.";
        public static string RegisteredEmail { get; set; } = "Please Enter Registered Email";
        public static string SuccessMsg { get; set; } = "Saved Successfully.";
        public static string DataRemoveMsg { get; set; } = "Removed Successfully.";
        public static string DataSuccessMsg { get; set; } = "Data saved successfully.";
        public static string SomethingWentWrong { get; set; } = "Something went wrong. Please refresh the page or try again later.";
        public static string CodeSent { get; set; } = "Verification code has been sent to {0}.";
        public static string InvalidVerificationCode { get; set; } = "Verification code does not match.";
        public static string UnAuthorizedUser { get; set; } = "Request not authorized. Please reload the page or login again.";
        public static string PasswordUpdated { get; set; } = "Password has been updated successfully.";
        public static string InvalidPassword { get; set; } = "New password does not follow the rule.";
        public static string InvalidRequest { get; set; } = "Invalid Request";
        public static string SuccessEmailVerified { get; set; } = "Congratulations! You have successfully verified [email]. Please login with provided credentials in email.";
        public static string CodeVerifiedSuccess { get; set; } = "Your verification code is verified successfully. Please reset your password.";
        public static string PassWordAlreadyCreated { get; set; } = "Password has already created.";
        public static string VerificationCodeInvalid { get; set; } = "Either verification code has expired or invalid.";
        public static string EmailAuthorizedSuccessMsg { get; set; } = "Account authorized successfully.";
        public static string InvalidLoginRequest { get; set; } = "Invalid login request.";
        public static string AccountChange { get; set; } = "Please wait while we are authenticating {0}'s Account.";
        public static string NotificationRemoved { get; set; } = "That notification has been removed.";
        public static string LinkExpired { get; set; } = "This link is expired.";
        public static string EmailSent { get; set; } = "Email sent successfully. Please check your e-mail.";
        public static string InvalidOldPassWord { get; set; } = "Invalid old password";
        public static string LogInExecption { get; set; } = "Please fill in all the blancks!";
        public static string InActiveUser { get; set; } = "You cannot inactive logged in user!";
        public static string DeleteUserException { get; set; } = "You cannot delete logged in user!";
        public static string InvalidEmail { get; set; } = "Email is not valid!";
        public static string IdNotNull { get; set; } = "Id cannot be null!";
        public static string DeleteSuccess { get; set; } = "Data deleted successfully.";
        public static string InValidUser { get; set; } = "Unauthorized User";
        public static string IdentifierNotExists { get; set; } = "Identifier does not exist in this HRIS.";
    }

    public static class CommonPath
    {
        public static string RootPath { get; set; }
        public static string ProfilePicPath { get; set; } = "\\userprofile\\profilepic\\original\\";
        public static string ClientLogoPath { get; set; } = "\\clientlogo\\original\\";
        public static string SurveyLogo { get; set; } = "\\surveyLogo\\";
        public static string HRISFilePath { get; set; } = "\\hris\\";
    }
    public static class CommonLanguageId
    {
        public static int EnglishLangId { get; set; } = 1;
    }

    public static class CommonMinutes
    {
        public static string DefaultExpiryMinutes = "240"; // Default expiry minutes for jwt token.
        public static string RememberExpiryMinutes = "480"; // Expiry minutes for jwt token if remember is checked.
    }
}
