using MediatR;
using RhProject.Application.Exceptions;
using RhProject.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace RhProject.Application.Commands.Cooperado.AtualizarCooperado
{
    public class AtualizarCooperadoCommandHandler : IRequestHandler<AtualizarCooperadoCommand, Unit>
    {
        private readonly IRepositoryBase<Domain.Entities.Cooperado> _repository;
        private readonly IRepositoryBase<Domain.Entities.Base> _baseRepository;

        public AtualizarCooperadoCommandHandler(IRepositoryBase<Domain.Entities.Cooperado> repository, IRepositoryBase<Domain.Entities.Base> baseRepository)
        {
            _repository = repository;
            _baseRepository = baseRepository;
        }

        public async Task<Unit> Handle(AtualizarCooperadoCommand request, CancellationToken cancellationToken)
        {

            var baseEntity = await _baseRepository.ObterPorIdAsync(request.BaseId, cancellationToken);

            if(baseEntity == null)
            {
                throw new NotFoundException("Base não encontrada.");
            }

            var cooperadoExistente = await _repository.ObterPorIdAsync(request.Id, cancellationToken);
            
            if (cooperadoExistente == null)
            {
                throw new NotFoundException("Cooperado não encontrado.");
            }

            cooperadoExistente.Atualizar(request.Nome, request.Email, request.Telefone, request.FuncaoId, baseEntity);

            await _repository.Alterar(cooperadoExistente, cancellationToken);

            await _repository.CommitAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
