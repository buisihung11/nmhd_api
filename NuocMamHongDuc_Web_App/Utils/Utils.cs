using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NuocMamHongDuc_Web_App.Utils
{
    public class Utils
    {
        public static String GetHash(string password, string salt)
        {
            byte[] unhashedBytes = Encoding.Unicode.GetBytes(String.Concat(salt, password));

            SHA256Managed sha256 = new SHA256Managed();
            byte[] hashedBytes = sha256.ComputeHash(unhashedBytes);
            return BitConverter.ToString(hashedBytes);
        }

        public static bool CompareHash(string attemptedPassword, byte[] hash, string salt)
        {
            string base64Hash = Convert.ToBase64String(hash);
            string base64AttemptedHash = GetHash(attemptedPassword, salt);

            var test = base64Hash == base64AttemptedHash;
            return test;
        }

        public static void CopyValues<T>(T target, T source)
        {
            Type t = typeof(T);

            var properties = t.GetProperties().Where(prop => prop.CanRead && prop.CanWrite);

            foreach (var prop in properties)
            {
                var value = prop.GetValue(source, null);
                if (prop.Name.Contains("Pass") && value != null)
                {
                    prop.SetValue(target, value, null);
                    continue;
                }
                if (prop.CustomAttributes.Any(a => a.AttributeType == typeof(System.Attribute)))
                    continue;
                if (value != null && !prop.Name.Contains("Code") && !prop.Name.Contains("Id") && !prop.Name.Contains("Active") && !value.GetType().IsGenericType && !(value is IList))
                {
                    prop.SetValue(target, value, null);
                }
            }
        }
    }
}
