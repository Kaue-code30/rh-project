using MediatR;
using RhProject.Application.DTOs.Usuario;
using RhProject.Application.Exceptions;
using RhProject.Application.Interfaces.Authorization;
using RhProject.Application.Interfaces.Security;
using RhProject.Domain.Interfaces.Repository;

namespace RhProject.Application.Queries.Usuario.PerfilLogado
{
    public class PerfilUsuarioLogadoQueryHandler : IRequestHandler<PerfilUsuarioLogadoQuery, PerfilUsuarioLogadoDto>
    {
        private readonly IRepositoryBase<Domain.Entities.UsuarioPerfil> _repository;
        private readonly IUsuarioLogadoService _usuarioLogadoService;
        private readonly IRepositoryBase<Domain.Entities.Usuario> _usuarioService;
        private readonly IPermissaoService _permissaoService;

        public PerfilUsuarioLogadoQueryHandler(
            IRepositoryBase<Domain.Entities.UsuarioPerfil> repository, 
            IUsuarioLogadoService usuarioLogadoService,
            IRepositoryBase<Domain.Entities.Usuario> usuarioService,
            IPermissaoService permissaoService)
        {
            _repository = repository;
            _usuarioLogadoService = usuarioLogadoService;
            _usuarioService = usuarioService;
            _permissaoService = permissaoService;
        }

        public async Task<PerfilUsuarioLogadoDto> Handle(PerfilUsuarioLogadoQuery request, CancellationToken cancellationToken)
        {

            var usuarioLogadoEstaAutenticado = _usuarioLogadoService.EstaAutenticado;
            var usuarioLogadoId = _usuarioLogadoService.UsuarioId;


            if (!usuarioLogadoEstaAutenticado)
            {
                throw new UnauthorizedAccessException("Usuário não autenticado.");
            }

            var perfilUsuarioLogadoResult = new PerfilUsuarioLogadoDto();

            var usuarioPerfil = await _repository.ObterPorCondicaoAsync(up => up.UsuarioId == usuarioLogadoId && up.Ativo && up.Perfil.Ativo, cancellationToken);

            if (usuarioPerfil == null)
            {
                throw new NotFoundException("Perfil do usuário não encontrado.");
            } 

            var usuario = await _usuarioService.ObterPorIdAsync(usuarioPerfil.UsuarioId, cancellationToken);

            if (usuario == null)
            {
                throw new NotFoundException("Usuário não encontrado.");
            }

            var usuarioTipoPerfil = (PerfilEnum)usuarioPerfil.PerfilId;

            perfilUsuarioLogadoResult.Id = usuario.Id;
            perfilUsuarioLogadoResult.Email = usuario.Email;
            perfilUsuarioLogadoResult.Nome = usuario.Nome;
            perfilUsuarioLogadoResult.TipoUsuarioDescricao = usuarioTipoPerfil.ToString();

            var permissoes = await _permissaoService.ObterPermissoesDoUsuario(usuario.Id, cancellationToken);

            perfilUsuarioLogadoResult.Permissoes = permissoes;

            return perfilUsuarioLogadoResult;
        }
    }
}
