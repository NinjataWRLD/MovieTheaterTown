using System.Security.Cryptography;

namespace MovieTheaterTown.API
{
    public class KeyGenerator
    {
        public static string GenerateSecretKey(int keyLengthInBytes)
        {
            byte[] keyBytes = new byte[keyLengthInBytes];
            using RandomNumberGenerator rng = RandomNumberGenerator.Create();
            rng.GetBytes(keyBytes);

            string secretKey = Convert.ToBase64String(keyBytes);
            return secretKey;
        }
    }
}
