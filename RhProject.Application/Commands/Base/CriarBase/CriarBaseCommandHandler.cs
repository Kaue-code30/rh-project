using MediatR;
using RhProject.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace RhProject.Application.Commands.Base.CriarBase
{
    public class CriarBaseCommandHandler : IRequestHandler<CriarBaseCommand, int>
    {
        private readonly IRepositoryBase<Domain.Entities.Base> _repository;

        public CriarBaseCommandHandler(IRepositoryBase<Domain.Entities.Base> repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CriarBaseCommand request, CancellationToken cancellationToken)
        {
            var empBase = new Domain.Entities.Base(request.Nome, request.Descricao);

            await _repository.AdicionarAsync(empBase, cancellationToken);

            await _repository.CommitAsync(cancellationToken);

            return empBase.Id;
        }
    }
}
