using RhProject.Domain.Enums;

namespace RhProject.Application.Interfaces.Authorization
{
    public interface IPerfilUsuarioService
    {
        Task<bool> UsuarioEhAdministradorAsync(int usuarioId, CancellationToken cancellationToken = default);

        Task<bool> UsuarioEhCoordenadorAsync(int usuarioId, CancellationToken cancellationToken = default);

        Task<bool> UsuarioEhCooperadoAsync(int usuarioId, CancellationToken cancellationToken = default);

        Task<bool> UsuarioPossuiPerfilAsync(int usuarioId, PerfilEnum perfil, CancellationToken cancellationToken = default);
    }
}