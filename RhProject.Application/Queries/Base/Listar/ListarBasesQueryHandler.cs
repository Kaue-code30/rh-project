using MediatR;
using RhProject.Application.DTOs.Base;
using RhProject.Application.Queries.Base.Listar;
using RhProject.Domain.Interfaces.Repository;

namespace RhProject.Application.Queries.Base.Listar
{
    public class ListarBasesQueryHandler : IRequestHandler<ListarBasesQuery, List<BaseDto>>
    {
        private readonly IRepositoryBase<Domain.Entities.Base> _repository;

        public ListarBasesQueryHandler(IRepositoryBase<Domain.Entities.Base> repository)
        {
            _repository = repository;
        }

        public async Task<List<BaseDto>> Handle(ListarBasesQuery request, CancellationToken cancellationToken)
        {
            var bases = await _repository.ObterTodosAsync(cancellationToken);

            return bases.Select(x => new BaseDto
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    Descricao = x.Descricao
            }).ToList();
        }
    }
}