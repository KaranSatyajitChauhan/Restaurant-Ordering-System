using Microsoft.AspNetCore.Identity;

namespace Week_10_Class_1_DW4.Services
{
    public interface IPasswordService
    {
        string HashPassword(string password);
        bool VerifyPassword(string hashedPassword, string providedPassword);
    }
    public class PasswordService : IPasswordService
    {
        private readonly PasswordHasher<string> _passwordHasher = new PasswordHasher<string>();

        public string HashPassword(string password)
        {
            return _passwordHasher.HashPassword(null, password);
        }

        public bool VerifyPassword(string hashedPassword, string providedPassword)
        {
            var result = _passwordHasher.VerifyHashedPassword(null, hashedPassword, providedPassword);
            return result == PasswordVerificationResult.Success;
        }
    }
}
