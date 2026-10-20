using RhProject.Domain.Entities;
using RhProject.Domain.Interfaces.Repository;
using RhProject.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace RhProject.Infrastructure.Repositories
{
    public class CooperadoRepository : RepositoryBase<Domain.Entities.Cooperado>, ICooperadoRepository
    {
        public CooperadoRepository(RhContext context) : base(context){}

        public async Task<List<Cooperado>> ObterPorFuncaoAsync(int funcaoId, CancellationToken cancellationToken)
        {
            return await _context
                .Set<Cooperado>()
                .Include(x => x.Funcao)
                .AsNoTracking()
                .Where(x => x.FuncaoId == funcaoId && x.Ativo)
                .ToListAsync(cancellationToken);
        }

        public override Task<List<Cooperado>> ObterTodosAsync(CancellationToken cancellationToken)
        {
            return _context.Set<Cooperado>()
                .Include(x => x.Funcao)
                .Where(x => x.Ativo)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}