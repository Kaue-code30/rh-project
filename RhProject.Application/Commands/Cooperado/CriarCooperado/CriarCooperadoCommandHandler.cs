using MediatR;
using RhProject.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace RhProject.Application.Commands.Base.CriarBase
{
    public class CriarCooperadoCommandHandler : IRequestHandler<CriarCooperadoCommand, int>
    {
        private readonly IRepositoryBase<Domain.Entities.Cooperado> _repository;

        public CriarCooperadoCommandHandler(IRepositoryBase<Domain.Entities.Cooperado> repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CriarCooperadoCommand request, CancellationToken cancellationToken)
        {
            var cooperado = new Domain.Entities.Cooperado(request.Nome, request.Email, request.Cpf, request.Telefone, request.DataNascimento, request.DataInicio, request.FuncaoId);

            await _repository.AdicionarAsync(cooperado, cancellationToken);

            await _repository.CommitAsync(cancellationToken);

            return cooperado.Id;
        }
    }
}
