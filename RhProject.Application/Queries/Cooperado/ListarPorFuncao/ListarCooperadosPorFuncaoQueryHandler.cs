using MediatR;
using RhProject.Application.DTOs;
using RhProject.Application.DTOs.Cooperado;
using RhProject.Domain.Interfaces.Repository;

namespace RhProject.Application.Queries.Cooperado.Listar
{
    public class ListarCooperadosPorFuncaoQueryHandler : IRequestHandler<ListarCooperadosPorFuncaoQuery, List<CooperadoDto>>
    {
        private readonly IRepositoryBase<Domain.Entities.Cooperado> _repository;
        private readonly ICooperadoRepository _cooperadoRepository;

        public ListarCooperadosPorFuncaoQueryHandler(IRepositoryBase<Domain.Entities.Cooperado> repository, ICooperadoRepository cooperadoRepository)
        {
            _repository = repository;
            _cooperadoRepository = cooperadoRepository;
        }

        public async Task<List<CooperadoDto>> Handle(ListarCooperadosPorFuncaoQuery request, CancellationToken cancellationToken)
        {
            var cooperados = await _cooperadoRepository.ObterPorFuncaoAsync(request.FuncaoId, cancellationToken);

            return cooperados.Select(x => new CooperadoDto
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    Email = x.Email,
                    Cpf = x.Cpf,
                    Telefone = x.Telefone,
                    DataNascimento = x.DataNascimento,
                    DataInicio = x.DataInicio,
                    FuncaoId = x.FuncaoId
                }).ToList();
        }
    }
}