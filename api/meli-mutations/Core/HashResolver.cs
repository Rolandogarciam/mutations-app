using System.Security.Cryptography;
using System.Text;

public static class HashResolver {
    public static string Resolve(string plainText) {
        string result = string.Empty;
        using (var hashingService = SHA256.Create())
        {
            byte[] hash = hashingService.ComputeHash(Encoding.UTF8.GetBytes(plainText));

            result = string.Concat(Array.ConvertAll(hash, h => h.ToString("X2")));
        }
        return result;
    }
}