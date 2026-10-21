using MediatR;
using RhProject.Application.Exceptions;
using RhProject.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace RhProject.Application.Commands.Base.ExcluirBase
{
    public class ExcluirBaseCommandHandler : IRequestHandler<ExcluirBaseCommand, Unit>
    {
        private readonly IRepositoryBase<Domain.Entities.Base> _repository;

        public ExcluirBaseCommandHandler(IRepositoryBase<Domain.Entities.Base> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(ExcluirBaseCommand request, CancellationToken cancellationToken)
        {
            var empBase = await _repository.ObterPorIdAsync(request.Id, cancellationToken);

            if (empBase == null)
            {
                throw new BadRequestException("Base não encontrada.");
            }

            await _repository.Remover(empBase, cancellationToken);

            await _repository.CommitAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
