using RhProject.Domain.Entities;
using RhProject.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using RhProject.Infrastructure.Context;

namespace RhProject.Infrastructure.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : BaseEntity
    {

        protected readonly RhContext _context;

        public RepositoryBase(RhContext context)
        {
            _context = context;
        }

        public async Task<TEntity?> ObterPorIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task AdicionarAsync(TEntity entity, CancellationToken cancellationToken)
        {
            await _context.Set<TEntity>().AddAsync(entity, cancellationToken);
        }

        public void Alterar(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }

        public void Remover(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public async Task CommitAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}