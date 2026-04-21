using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace NetworkMonitoring.Shared.Security
{
    public static class CryptoHelper
    {
        public static string Encrypt(string plainText, string sharedKey)
        {
            using var aes = Aes.Create();
            aes.Key = new byte[32]; aes.IV = new byte[16];
            var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            using var ms = new MemoryStream();
            using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
            {
                var bytes = Encoding.UTF8.GetBytes(plainText);
                cs.Write(bytes, 0, bytes.Length);
            }
            return Convert.ToBase64String(ms.ToArray());
        }

        public static string Decrypt(string cipherText, string sharedKey)
        {
            var buffer = Convert.FromBase64String(cipherText);
            using var aes = Aes.Create();
            aes.Key = new byte[32]; aes.IV = new byte[16];
            var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            using var ms = new MemoryStream();
            using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Write))
            {
                cs.Write(buffer, 0, buffer.Length);
            }
            return Encoding.UTF8.GetString(ms.ToArray());
        }
    }
}
