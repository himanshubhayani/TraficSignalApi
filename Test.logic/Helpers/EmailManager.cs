using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace Test.helper
{
    public class EmailManager
    {
        public static void SendMail(string mTo, string mSubject, string mBody)
        {
            SendMail(mTo, mSubject, mBody, null);
        }

        public static void SendMail(string mTo, string mSubject, string mBody, Attachment Attachments)  //AttachmentCollection
        {
            string mailBody = mBody;

            string mailServer = "smtp.gmail.com";
            string mailUser = "teamabel703@gmail.com";
            string mailPassword = "abel@123";
            string mailTo = mTo;
            string mailFrom = "do_not_reply@TechAvidus.com";
            int port = 587;

            if (string.IsNullOrEmpty(mTo))
                mTo = mailTo;

            MailMessage mailObject = new MailMessage();
            mailObject.To.Add(mTo);
            mailObject.From = new MailAddress(mailFrom, mailFrom);

            mailObject.Subject = mSubject;
            mailObject.IsBodyHtml = true;
            mailObject.Body = mailBody;
            mailObject.BodyEncoding = System.Text.Encoding.UTF8;
            mailObject.SubjectEncoding = System.Text.Encoding.UTF8;

            //rvb 27/11/2016 Comment out for moment, but we may re-instate later if Origin want this feature
            if (Attachments != null)
            {
                //foreach (var attachment in Attachments)
                //{
                mailObject.Attachments.Add(Attachments);
                //}
            }

            SmtpClient smtp = new SmtpClient();

            smtp.Host = mailServer;
            smtp.Port = port;
            smtp.EnableSsl = true;
            System.Net.NetworkCredential basicAuthenticationInfo = new System.Net.NetworkCredential(mailUser, mailPassword);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = basicAuthenticationInfo;

            smtp.Send(mailObject);
        }

        #region Send Email Async
        public static async Task SendMailAsync(string mTo, string mSubject, string mBody)
        {
            await Task.Run(() => SendMailAsync(mTo, mSubject, mBody, null));
        }

        public static async Task SendMailAsync(string mTo, string mSubject, string mBody, Attachment Attachments)  //AttachmentCollection
        {
            string mailBody = mBody;
            string mailServer = "smtp.gmail.com";
            string mailUser = "teamabel703@gmail.com";
            string mailPassword = "abel@123";
            string mailTo = mTo;
            string mailFrom = "do_not_reply@TechAvidus.com";
            int port = 587;

            if (string.IsNullOrEmpty(mTo))
                mTo = mailTo;

            MailMessage mailObject = new MailMessage();
            mailObject.To.Add(mTo);
            mailObject.From = new MailAddress(mailFrom, mailFrom);

            mailObject.Subject = mSubject;
            mailObject.IsBodyHtml = true;
            mailObject.Body = mailBody;
            mailObject.BodyEncoding = System.Text.Encoding.UTF8;
            mailObject.SubjectEncoding = System.Text.Encoding.UTF8;

            //rvb 27/11/2016 Comment out for moment, but we may re-instate later if Origin want this feature
            if (Attachments != null)
            {
                //foreach (var attachment in Attachments)
                //{
                mailObject.Attachments.Add(Attachments);
                //}
            }

            SmtpClient smtp = new SmtpClient();

            smtp.Host = mailServer;
            smtp.Port = port;
            smtp.EnableSsl = true;
            System.Net.NetworkCredential basicAuthenticationInfo = new System.Net.NetworkCredential(mailUser, mailPassword);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = basicAuthenticationInfo;

            smtp.Send(mailObject);
            Console.WriteLine("after mail sent");
        }
        #endregion
    }
}