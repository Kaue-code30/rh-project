public interface IUsuarioBaseRepository
{
    Task<bool> UsuarioPossuiBaseAsync(
           int usuarioId,
           int baseId,
           CancellationToken cancellationToken);

    Task<List<int>> ObterBasesIdsPorUsuarioAsync(
        int usuarioId,
        CancellationToken cancellationToken);
}