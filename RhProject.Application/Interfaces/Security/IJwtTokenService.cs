using RhProject.Application.Response.Auth;
using RhProject.Domain.Entities;

namespace RhProject.Application.Interfaces.Security
{
    public interface IJwtTokenService
    {
        LoginResponse GerarToken(Usuario usuario);
    }
}