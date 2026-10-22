using MediatR;
using RhProject.Application.Exceptions;
using RhProject.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace RhProject.Application.Commands.Base.AtualizarBase
{
    public class AtualizarBaseCommandHandler : IRequestHandler<AtualizarBaseCommand, Unit>
    {
        private readonly IRepositoryBase<Domain.Entities.Base> _repository;

        public AtualizarBaseCommandHandler(IRepositoryBase<Domain.Entities.Base> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(AtualizarBaseCommand request, CancellationToken cancellationToken)
        {
            var empBase = await _repository.ObterPorIdAsync(request.Id, cancellationToken);

            if (empBase == null)
            {
                throw new BadRequestException("Base não encontrada.");
            }

            empBase.Atualizar(request.Nome, request.Descricao);

            await _repository.Alterar(empBase, cancellationToken);

            await _repository.CommitAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
