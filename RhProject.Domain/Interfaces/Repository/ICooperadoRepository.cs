using System;
using System.Collections.Generic;
using System.Text;

namespace RhProject.Domain.Interfaces.Repository
{
    public interface ICooperadoRepository : IRepositoryBase<Entities.Cooperado>
    {
        Task<List<Entities.Cooperado>> ObterPorFuncaoAsync(int funcaoId, CancellationToken cancellationToken);
        Task<List<Entities.Cooperado>> ObterPorBaseAsync(int baseId, CancellationToken cancellationToken);
    }
}
