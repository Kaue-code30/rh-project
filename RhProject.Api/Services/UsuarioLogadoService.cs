using RhProject.Application.Interfaces.Authorization;
using System.Security.Claims;

namespace RhProject.Api.Services.Authorization
{
    public class UsuarioLogadoService : IUsuarioLogadoService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPerfilUsuarioService _perfilUsuarioService;

        public UsuarioLogadoService(
            IHttpContextAccessor httpContextAccessor,
            IPerfilUsuarioService perfilUsuarioService)
        {
            _httpContextAccessor = httpContextAccessor;
            _perfilUsuarioService = perfilUsuarioService;
        }

        private ClaimsPrincipal? Usuario => _httpContextAccessor.HttpContext?.User;

        public bool EstaAutenticado => Usuario?.Identity?.IsAuthenticated == true;
        public int BaseId
        {
            get
            {
                var baseIdClaim = Usuario?.FindFirst("baseId")?.Value;

                if (!int.TryParse(baseIdClaim, out var baseId) || baseId <= 0)
                    throw new InvalidOperationException(
                        "O usuário autenticado não possui uma base válida.");

                return baseId;
            }
        }

        public int? UsuarioId
        {
            get
            {
                if (!EstaAutenticado)
                    return null;

                var claim = Usuario?.FindFirst("sub")?.Value ?? Usuario?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                return int.TryParse(claim, out var usuarioId) ? usuarioId : null;
            }
        }

        public string? Email => EstaAutenticado ? Usuario?.FindFirst("email")?.Value ?? Usuario?.FindFirst(ClaimTypes.Email)?.Value : null;

        public int ObterUsuarioId()
        {
            return UsuarioId ?? throw new UnauthorizedAccessException("Usuário não autenticado ou token inválido.");
        }

        public Task<bool> EhAdministradorAsync(CancellationToken cancellationToken = default)
        {
            return _perfilUsuarioService.UsuarioEhAdministradorAsync(ObterUsuarioId(), cancellationToken);
        }

        public Task<bool> EhCoordenadorAsync(CancellationToken cancellationToken = default)
        {
            return _perfilUsuarioService.UsuarioEhCoordenadorAsync(ObterUsuarioId(), cancellationToken);
        }

        public Task<bool> EhCooperadoAsync(CancellationToken cancellationToken = default)
        {
            return _perfilUsuarioService.UsuarioEhCooperadoAsync(ObterUsuarioId(), cancellationToken);
        }
    }
}