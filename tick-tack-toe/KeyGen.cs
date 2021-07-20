using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace tick_tack_toe
{
    public static class KeyGen
    {
        private static RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

        public static byte[] GenerateSecretKey()
        {
            byte[] secretkey = new Byte[16];
            rng.GetBytes(secretkey);
            return secretkey;
        }

        public static string GenerateHMAC(byte[] key, string move)
        {
            using (var shaAlgorithm = new HMACSHA256(key))
            {
                var signatureBytes = System.Text.Encoding.UTF8.GetBytes(move);
                var signatureHashBytes = shaAlgorithm.ComputeHash(signatureBytes);
                var signatureHashHex = string.Concat(Array.ConvertAll(signatureHashBytes, b => b.ToString("X2")));
                return signatureHashHex;
            }
        }
    }
}