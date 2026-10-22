using MediatR;
using RhProject.Application.Interfaces.Security;
using RhProject.Application.Response.Auth;
using UsuarioEntity = RhProject.Domain.Entities.Usuario;
using RhProject.Domain.Interfaces.Repository;

namespace RhProject.Application.Commands.Auth.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly IRepositoryBase<UsuarioEntity> _repository;
        private readonly IPasswordService _passwordService;
        private readonly IJwtTokenService _jwtTokenService;

        public LoginCommandHandler(IRepositoryBase<UsuarioEntity> repository, IPasswordService passwordService, IJwtTokenService jwtTokenService)
        {
            _repository = repository;
            _passwordService = passwordService;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var email = request.Email.Trim().ToLowerInvariant();

            var usuario = await _repository.ObterPorCondicaoAsync(u => u.Email == email && u.Ativo, cancellationToken);

            if(usuario == null)
            {
                throw new UnauthorizedAccessException("Usuário ou senha incorretos.");
            }

            var senhaValida = _passwordService.VerifyPassword(request.Senha, usuario.SenhaHash);

            if(!senhaValida)
            {
                throw new UnauthorizedAccessException("Usuário ou senha incorretos.");
            }

            return _jwtTokenService.GerarToken(usuario);
        }

    }
}
