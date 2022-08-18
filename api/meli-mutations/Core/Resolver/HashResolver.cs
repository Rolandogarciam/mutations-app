using System.Security.Cryptography;
using System.Text;

namespace meli_mutations.Core.Resolver;

public static class HashResolver {
    public static string Resolve(string plainText) {
        string result = string.Empty;
        using (var hashingService = SHA512.Create())
        {
            byte[] hash = hashingService.ComputeHash(Encoding.UTF8.GetBytes(plainText));

            result = string.Concat(Array.ConvertAll(hash, h => h.ToString("X2")));
        }
        return result;
    }
}