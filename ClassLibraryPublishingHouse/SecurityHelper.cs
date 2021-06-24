using System;
using System.Security.Cryptography;
using System.Text;

namespace PublishingHouse
{
    public class SecurityHelper
    {
        public static string HashPassword(string password, string salt, int nIterations, int nHash)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] saltBytes = encoding.GetBytes(salt);

            using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, nIterations))
            {
                return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(nHash));
            }
        }
    }
}