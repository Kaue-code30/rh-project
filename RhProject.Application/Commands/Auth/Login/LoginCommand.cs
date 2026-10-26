using MediatR;
using RhProject.Application.Response.Auth;

namespace RhProject.Application.Commands.Auth.Login
{
    public class LoginCommand : IRequest<LoginResponse>
    {
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
    }
}