using RhProject.Application.DTOs.Cooperado;
using System;
using System.Collections.Generic;
using System.Text;

namespace RhProject.Application.Interfaces.Authorization
{
    public interface IPermissaoService
    {
        Task<bool> UsuarioTemPermissaoAsync(int usuarioId, string codigoPermissao, CancellationToken cancellationToken);
        Task<List<PermissaoDto>> ObterPermissoesDoUsuario(int usuarioId, CancellationToken cancellationToken);
    }
}
