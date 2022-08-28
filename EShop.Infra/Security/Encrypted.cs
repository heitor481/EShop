using System;
using System.Security.Cryptography;

namespace EShop.Infra.Security
{
    public class Encrypted : IEncrypter
    {
        private readonly string Salt = "J:4=2cMIIkFG.6jWb7Z:x(VB)ZWYF+VZ(O9VXcNFS5BTAVIg6Q";

        public string GetHash(string value, string salt)
        {
            var derivedBytes = new Rfc2898DeriveBytes(value, GetBytes(salt), 1000);
            return Convert.ToBase64String(derivedBytes.GetBytes(50));
        }

        public string GetSalt()
        {
            return Salt;
        }

        private static byte[] GetBytes(string value)
        {
            var bytes = new Byte[value.Length];
            Buffer.BlockCopy(value.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }
    }
}
