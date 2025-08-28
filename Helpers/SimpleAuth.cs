using System;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace Personal_Portfolio2.Helpers
{
    public static class SimpleAuth
    {
        public static bool Validate(string user, string pass)
        {
            var cfgUser = ConfigurationManager.AppSettings["AdminUsername"];
            var cfgHash = ConfigurationManager.AppSettings["AdminPasswordHash"];
            if (string.IsNullOrWhiteSpace(cfgUser) || string.IsNullOrWhiteSpace(cfgHash)) return false;

            return string.Equals(cfgUser, user, StringComparison.OrdinalIgnoreCase)
                && string.Equals(cfgHash, Sha256(pass), StringComparison.OrdinalIgnoreCase);
        }

        private static string Sha256(string input)
        {
            using (var sha = SHA256.Create())
            {
                var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder();
                foreach (var b in bytes) sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }
    }
}
