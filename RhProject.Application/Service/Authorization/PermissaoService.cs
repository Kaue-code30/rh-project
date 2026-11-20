using RhProject.Application.DTOs.Cooperado;
using RhProject.Application.Interfaces.Authorization;
using RhProject.Domain.Entities;
using RhProject.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace RhProject.Application.Service.Authorization
{
    public class PermissaoService : IPermissaoService
    {

        private readonly IRepositoryBase<UsuarioPerfil> _usuarioPerfilRepository;
        private readonly IRepositoryBase<PerfilPermissao> _perfilPermissaoRepository;

        public PermissaoService(IRepositoryBase<UsuarioPerfil> usuarioPerfilRepository, IRepositoryBase<PerfilPermissao> perfilPermissaoRepository)
        {
            _usuarioPerfilRepository = usuarioPerfilRepository;
            _perfilPermissaoRepository = perfilPermissaoRepository;
        }

        public async Task<bool> UsuarioTemPermissaoAsync(int usuarioId, string codigoPermissao, CancellationToken cancellationToken)
        {
            var usuarioPerfil = await _usuarioPerfilRepository.ObterPorCondicaoAsync(up => up.UsuarioId == usuarioId && up.Ativo, cancellationToken);

            if (usuarioPerfil is null)
                return false;


            var perfilPermissao =
                await _perfilPermissaoRepository.ObterPorCondicaoAsync(
                    p => p.PerfilId == usuarioPerfil.PerfilId
                    && p.Permissao.Codigo == codigoPermissao
                    && p.Permissao.Ativo
                    && p.Ativo,
                    cancellationToken);

            return perfilPermissao is not null;
        }

        public async Task<List<PermissaoDto>> ObterPermissoesDoUsuario(int usuarioId, CancellationToken cancellationToken)
        {
            var usuarioPerfil = await _usuarioPerfilRepository.ObterPorCondicaoAsync(up => up.UsuarioId == usuarioId && up.Ativo, cancellationToken);

            if (usuarioPerfil is null)
                return new List<PermissaoDto>();

            var permissoes =
                await _perfilPermissaoRepository.ObterTodosPorCondicaoAsync(
                    pp => pp.PerfilId == usuarioPerfil.PerfilId
                        && pp.Permissao.Ativo
                        && pp.Ativo,
                    cancellationToken,
                    pp => pp.Permissao);

            return permissoes.Select(p => new PermissaoDto
            { 
                Codigo = p.Permissao.Codigo,
                Descricao = p.Permissao.Descricao, 
                Id = p.Permissao.Id, 
                Modulo = p.Permissao.Modulo }).ToList();
        }
    }
}
