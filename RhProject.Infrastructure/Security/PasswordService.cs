using Microsoft.AspNetCore.Identity;
using RhProject.Application.Interfaces.Security;

namespace RhProject.Infrastructure.Security
{
    public class PasswordService : IPasswordService
    {
        private readonly PasswordHasher<object> _hasher = new();

        public string HashPassword(string senha)
        {
            return _hasher.HashPassword(null!, senha);
        }

        public bool VerifyPassword(string senha, string senhaHash)
        {
            var result = _hasher.VerifyHashedPassword(null!, senhaHash, senha);

            return result != PasswordVerificationResult.Failed;
        }
    }
}