using MediatR;
using RhProject.Application.Commands.Cooperado.ExcluirCooperado;
using RhProject.Application.Exceptions;
using RhProject.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace RhProject.Application.Commands.Base.ExcluirCooperado
{
    public class ExcluirCooperadoCommandHandler : IRequestHandler<ExcluirCooperadoCommand, Unit>
    {
        private readonly IRepositoryBase<Domain.Entities.Cooperado> _repository;

        public ExcluirCooperadoCommandHandler(IRepositoryBase<Domain.Entities.Cooperado> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(ExcluirCooperadoCommand request, CancellationToken cancellationToken)
        {
            foreach(var cooperadoId in request.CooperadosIds)
            {

                var cooperado = await _repository.ObterPorIdAsync(cooperadoId, cancellationToken);

                if (cooperado == null)
                {
                    throw new NotFoundException($"Cooperado {cooperadoId} não encontrado.");
                }

                await _repository.Remover(cooperado, cancellationToken);

            }

            await _repository.CommitAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
