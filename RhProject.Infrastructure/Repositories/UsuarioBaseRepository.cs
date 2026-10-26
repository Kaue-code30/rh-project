using Microsoft.EntityFrameworkCore;
using RhProject.Domain.Entities;
using RhProject.Domain.Interfaces.Repository;
using RhProject.Infrastructure.Context;

namespace RhProject.Infrastructure.Repositories
{
    public class UsuarioBaseRepository : IUsuarioBaseRepository
    {
        private readonly RhContext _context;

        public UsuarioBaseRepository(RhContext context)
        {
            _context = context;
        }

        public async Task<bool> UsuarioPossuiBaseAsync(int usuarioId, int baseId, CancellationToken cancellationToken)
        {
            return await _context
                .Set<UsuarioBase>()
                .AnyAsync(
                    x => x.UsuarioId == usuarioId
                         && x.BaseId == baseId
                         && x.Ativo,
                    cancellationToken);
        }

        public async Task<List<int>> ObterBasesIdsPorUsuarioAsync(int usuarioId, CancellationToken cancellationToken)
        {
            return await _context
                .Set<UsuarioBase>()
                .Where(x =>
                    x.UsuarioId == usuarioId &&
                    x.Ativo)
                .Select(x => x.BaseId)
                .ToListAsync(cancellationToken);
        }
    }
}