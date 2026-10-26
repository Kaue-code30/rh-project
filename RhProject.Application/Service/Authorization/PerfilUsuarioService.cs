using RhProject.Application.Interfaces.Authorization;
using RhProject.Domain.Entities;
using RhProject.Domain.Enums;
using RhProject.Domain.Interfaces.Repository;

namespace RhProject.Application.Service.Authorization
{
    public class PerfilUsuarioService : IPerfilUsuarioService
    {
        private readonly IRepositoryBase<UsuarioPerfil> _usuarioPerfilRepository;

        public PerfilUsuarioService(
            IRepositoryBase<UsuarioPerfil> usuarioPerfilRepository)
        {
            _usuarioPerfilRepository = usuarioPerfilRepository;
        }

        public Task<bool> UsuarioEhAdministradorAsync(int usuarioId, CancellationToken cancellationToken = default)
        {
            return UsuarioPossuiPerfilAsync(usuarioId, PerfilEnum.Administrador, cancellationToken);
        }

        public Task<bool> UsuarioEhCoordenadorAsync(int usuarioId, CancellationToken cancellationToken = default)
        {
            return UsuarioPossuiPerfilAsync(usuarioId, PerfilEnum.Coordenador, cancellationToken);
        }

        public Task<bool> UsuarioEhCooperadoAsync(int usuarioId, CancellationToken cancellationToken = default)
        {
            return UsuarioPossuiPerfilAsync(usuarioId, PerfilEnum.Cooperado, cancellationToken);
        }

        public async Task<bool> UsuarioPossuiPerfilAsync(int usuarioId, PerfilEnum perfil, CancellationToken cancellationToken = default)
        {
            var usuarioPerfil =
                await _usuarioPerfilRepository.ObterPorCondicaoAsync(
                    x => x.UsuarioId == usuarioId
                        && x.PerfilId == (int)perfil
                        && x.Ativo
                        && x.Usuario.Ativo
                        && x.Perfil.Ativo,
                    cancellationToken);

            return usuarioPerfil is not null;
        }
    }
}