using MediatR;
using RhProject.Application.Exceptions;
using RhProject.Application.Interfaces.Security;
using RhProject.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace RhProject.Application.Commands.Cooperado.CriarUsuario
{
    public class CriarUsuarioCooperadoCommandHandler : IRequestHandler<CriarUsuarioCooperadoCommand, int>
    {
        private readonly IRepositoryBase<Domain.Entities.Usuario> _repository;
        private readonly ICooperadoRepository _cooperadoRepository;
        private readonly IPasswordService _passwordService;

        public CriarUsuarioCooperadoCommandHandler(IRepositoryBase<Domain.Entities.Usuario> repository, ICooperadoRepository cooperadoRepository, IPasswordService passwordService)
        {
            _repository = repository;
            _cooperadoRepository = cooperadoRepository;
            _passwordService = passwordService;
        }

        public async Task<int> Handle(CriarUsuarioCooperadoCommand request, CancellationToken cancellationToken)
        {

           
            var usuarioCooperadoJaExiste = await _repository.ObterPorCondicaoAsync(usuario => usuario.CooperadoId == request.CooperadoId && usuario.Ativo, cancellationToken);

            if (usuarioCooperadoJaExiste!= null)
            {
                throw new ConflictException("Cooperado já possui um usuário cadastrado.");
            }

            var cooperadoExiste = await _cooperadoRepository.ObterPorCondicaoAsync(cooperado => cooperado.Id == request.CooperadoId && cooperado.Ativo, cancellationToken);

            if(cooperadoExiste == null)
            {
                throw new NotFoundException($"Cooperado com o id {request.CooperadoId} não foi encontrado.");
            }

            var senhaHash = _passwordService.HashPassword(request.Senha);

            var usuario = new Domain.Entities.Usuario(cooperadoExiste.Nome, cooperadoExiste.Email, senhaHash, request.CooperadoId);

            await _repository.AdicionarAsync(usuario, cancellationToken);

            await _repository.CommitAsync(cancellationToken);

            return usuario.Id;
        }
    }
}
