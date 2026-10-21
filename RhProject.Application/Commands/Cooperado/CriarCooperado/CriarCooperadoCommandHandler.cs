using MediatR;
using RhProject.Application.Exceptions;
using RhProject.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace RhProject.Application.Commands.Base.CriarBase
{
    public class CriarCooperadoCommandHandler : IRequestHandler<CriarCooperadoCommand, int>
    {
        private readonly IRepositoryBase<Domain.Entities.Cooperado> _repository;
        private readonly IRepositoryBase<Domain.Entities.Base> _baseRepository;

        public CriarCooperadoCommandHandler(IRepositoryBase<Domain.Entities.Cooperado> repository, IRepositoryBase<Domain.Entities.Base> baseRepository)
        {
            _repository = repository;
            _baseRepository = baseRepository;
        }

        public async Task<int> Handle(CriarCooperadoCommand request, CancellationToken cancellationToken)
        {

            var baseEntity = await _baseRepository.ObterPorIdAsync(request.BaseId, cancellationToken);

            if(baseEntity == null)
            {
                throw new NotFoundException("Base não encontrada.");
            }

            var cooperadoCpfExistente = await _repository.ObterPorCondicaoAsync(c => c.Cpf == request.Cpf, cancellationToken);

            if (cooperadoCpfExistente != null)
            {
                throw new ConflictException("Cooperado com este CPF já cadastrado.");
            }

            var cooperadoEmailExistente = await _repository.ObterPorCondicaoAsync(c => c.Email == request.Email, cancellationToken);

            if (cooperadoEmailExistente != null)
            {
                throw new ConflictException("Cooperado com este Email já cadastrado.");
            }

            var cooperado = new Domain.Entities.Cooperado(request.Nome, request.Email, request.Cpf, request.Telefone, request.DataNascimento, request.DataInicio, request.FuncaoId, request.BaseId);

            await _repository.AdicionarAsync(cooperado, cancellationToken);

            await _repository.CommitAsync(cancellationToken);

            return cooperado.Id;
        }
    }
}
