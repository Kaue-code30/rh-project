using RhProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace RhProject.Domain.Interfaces.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity?> ObterPorIdAsync(int id, CancellationToken cancellationToken);
        Task AdicionarAsync(TEntity entity, CancellationToken cancellationToken);
        void Alterar(TEntity entity);
        void Remover(TEntity entity);
        Task CommitAsync(CancellationToken cancellationToken);
        Task<List<TEntity>> ObterTodosAsync(CancellationToken cancellationToken);
        Task<List<TEntity>> ObterTodosPorCondicaoAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
        Task<TEntity?> ObterPorCondicaoAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
    }
}
