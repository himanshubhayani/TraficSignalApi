using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Drawing;

namespace Test.api
{
    public class Helper
    {
        private const string _key = "3nc7p1D3cr7p1";

        #region Encrypt - Decrypt

        /// <summary>
        /// Used to encrypt the password
        /// </summary>
        /// <param name="str">Plain password string</param>
        /// <returns></returns>
        public static string Encrypt(string str)
        {
            string EncrptKey = _key;
            byte[] byKey = { };
            byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
            byKey = System.Text.Encoding.UTF8.GetBytes(EncrptKey.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.UTF8.GetBytes(str);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Convert.ToBase64String(ms.ToArray());
        }

        /// <summary>
        /// Used to decrypt the password
        /// </summary>
        /// <param name="str">Encypted password string</param>
        /// <returns></returns>
        public static string Decrypt(string str)
        {
            str = str.Replace(" ", "+");
            string DecryptKey = _key;
            byte[] byKey = { };
            byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
            byte[] inputByteArray = new byte[str.Length];

            byKey = System.Text.Encoding.UTF8.GetBytes(DecryptKey.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            inputByteArray = Convert.FromBase64String(str.Replace(" ", "+"));
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            System.Text.Encoding encoding = System.Text.Encoding.UTF8;
            return encoding.GetString(ms.ToArray());
        }

        #endregion

        #region Convert base64 to image and save to local directory

        public static bool SaveOriginalImage(string RootPath, string ImgStr, string ImgName)
        {
            //Check if directory exist
            if (!Directory.Exists(RootPath))
            {
                Directory.CreateDirectory(RootPath);
            }

            if (File.Exists(RootPath + ImgName))
                File.Delete(RootPath + ImgName);

            var file = ImgStr.Substring(ImgStr.IndexOf(',') + 1);

            var fileName = DateTime.Now.ToString("yyyyMMdd_HHmmss") + "_" + ImgName;

            var filePath = RootPath + fileName;

            byte[] imageBytes = Convert.FromBase64String(file);

            File.WriteAllBytes(filePath, imageBytes);

            return true;
        }

        public static bool SaveImage(string RootPath, string ImgStr, string ImgName)
        {
            //Check if directory exist
            if (!Directory.Exists(RootPath))
            {
                Directory.CreateDirectory(RootPath); //Create directory if it doesn't exist
            }

            var file = ImgStr.Substring(ImgStr.IndexOf(',') + 1);

            //set the image path
            string imgPath = Path.Combine(RootPath, ImgName);

            byte[] imageBytes = Convert.FromBase64String(file);

            File.WriteAllBytes(imgPath, imageBytes);

            return true;
        }

        public static string ImageToBase64(string Image)
        {            
            byte[] b = File.ReadAllBytes(Image);
            return "data:image/png;base64," + Convert.ToBase64String(b);
        }

        //public static bool SaveThumbnailImage(string RootPath, string ImgStr, string ImgName)
        //{
        //    //Check if directory exist
        //    if (!Directory.Exists(RootPath))
        //        Directory.CreateDirectory(RootPath);


        //    //Check if same name file exist
        //    if (File.Exists(RootPath + "\\" + ImgName))
        //        File.Delete(RootPath + "\\" + ImgName);

        //    var file = ImgStr.Substring(ImgStr.IndexOf(',') + 1);

        //    var fileName = DateTime.Now.ToString("yyyyMMdd_HHmmss") + "_" + ImgName;

        //    var filePath = RootPath + "\\" + fileName;

        //    byte[] imageBytes = Convert.FromBase64String(file);

        //    File.WriteAllBytes(filePath, imageBytes);

        //    return true;
        //}
        #endregion
    }
}

