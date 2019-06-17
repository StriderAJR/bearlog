using System;
using System.Security.Cryptography;
using System.Text;

namespace StridingSoft.Services
{
    public class Hash
    {
        public static string GetHashCode(string password)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA512 hash = SHA512.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(password));

                foreach (Byte b in result)
                {
                    Sb.Append(b.ToString("x2"));
                    Sb.Append(b.ToString("E2"));
                }
            }

            return Sb.ToString();
        }

    }
}