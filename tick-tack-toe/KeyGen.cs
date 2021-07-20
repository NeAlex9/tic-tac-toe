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
            using (HMACSHA1 hmac = new HMACSHA1(key))
            {
                byte[] moveBytes = System.Text.Encoding.UTF8.GetBytes(move);  //??
                return Convert.ToBase64String(hmac.ComputeHash(moveBytes));
            }
        }
    }
}
