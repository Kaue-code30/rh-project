using MediatR;
using RhProject.Application.Exceptions;
using RhProject.Application.Interfaces.Security;
using RhProject.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace RhProject.Application.Commands.Cooperado.CriarUsuario
{
    public class CriarUsuarioCommandHandler : IRequestHandler<CriarUsuarioCommand, int>
    {
        private readonly IRepositoryBase<Domain.Entities.Usuario> _repository;
        private readonly IPasswordService _passwordService;

        public CriarUsuarioCommandHandler(IRepositoryBase<Domain.Entities.Usuario> repository, IPasswordService passwordService)
        {
            _repository = repository;
            _passwordService = passwordService;
        }

        public async Task<int> Handle(CriarUsuarioCommand request, CancellationToken cancellationToken)
        {

            var usuarioJaExiste = await _repository.ObterPorCondicaoAsync(usuario => usuario.Email == request.Email && usuario.Ativo, cancellationToken);

            if(usuarioJaExiste != null)
            {
                throw new ConflictException("Usuário já cadastrado.");
            }

            var senhaHash = _passwordService.HashPassword(request.Senha);

            var usuario = new Domain.Entities.Usuario(request.Nome, request.Email, senhaHash, request.CooperadoId);

            await _repository.AdicionarAsync(usuario, cancellationToken);

            await _repository.CommitAsync(cancellationToken);

            return usuario.Id;
        }
    }
}
