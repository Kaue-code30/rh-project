namespace RhProject.Application.Interfaces.Security
{
    public interface IPasswordService
    {
        string HashPassword(string senha);

        bool VerifyPassword(string senha, string senhaHash);
    }
}