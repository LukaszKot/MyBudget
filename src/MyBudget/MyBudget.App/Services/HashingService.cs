using System;
using System.Security.Cryptography;

namespace MyBudget.App.Services
{
    public class HashingService : IHashingService
    {
        public string Hash(string password)
        {
            var salt = new byte[16];
            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            rng.GetBytes(salt);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            return Convert.ToBase64String(hashBytes);
        }

        public bool CheckPassword(string hashedPassword, string password)
        {
            var hashBytes = Convert.FromBase64String(hashedPassword);
            var salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
            
            var hash = pbkdf2.GetBytes(20);
            
            for (var i=0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i])
                    return false;
            return true;
        }
    }
}

