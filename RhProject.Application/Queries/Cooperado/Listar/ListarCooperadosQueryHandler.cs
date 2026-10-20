using MediatR;
using RhProject.Application.DTOs;
using RhProject.Application.DTOs.Cooperado;
using RhProject.Domain.Interfaces.Repository;

namespace RhProject.Application.Queries.Cooperado.Listar
{
    public class ListarCooperadosQueryHandler : IRequestHandler<ListarCooperadosQuery, List<CooperadoDto>>
    {
        private readonly IRepositoryBase<Domain.Entities.Cooperado> _repository;
        private readonly ICooperadoRepository _cooperadoRepository;

        public ListarCooperadosQueryHandler(IRepositoryBase<Domain.Entities.Cooperado> repository, ICooperadoRepository cooperadoRepository)
        {
            _repository = repository;
            _cooperadoRepository = cooperadoRepository;
        }

        public async Task<List<CooperadoDto>> Handle(ListarCooperadosQuery request, CancellationToken cancellationToken)
        {
            var cooperados = await _cooperadoRepository.ObterTodosAsync(cancellationToken);

            return cooperados.Select(x => new CooperadoDto
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    Email = x.Email,
                    Cpf = x.Cpf,
                    Telefone = x.Telefone,
                    DataNascimento = x.DataNascimento,
                    DataInicio = x.DataInicio,
                    FuncaoId = x.FuncaoId,
                    Funcao = new DTOs.Funcao.FuncaoDto
                    {
                        Id = x.Funcao.Id,
                        Descricao = x.Funcao.Descricao
                    }
                }).ToList();
        }
    }
}