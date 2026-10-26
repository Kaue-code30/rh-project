namespace RhProject.Application.Interfaces.Authorization
{
    public interface IUsuarioLogadoService
    {
        int? UsuarioId { get; }

        string? Email { get; }

        bool EstaAutenticado { get; }

        int ObterUsuarioId();

        Task<bool> EhAdministradorAsync(CancellationToken cancellationToken = default);

        Task<bool> EhCoordenadorAsync(CancellationToken cancellationToken = default);

        Task<bool> EhCooperadoAsync(CancellationToken cancellationToken = default);
    }
}