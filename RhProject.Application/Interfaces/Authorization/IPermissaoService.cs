using System;
using System.Collections.Generic;
using System.Text;

namespace RhProject.Application.Interfaces.Authorization
{
    public interface IPermissaoService
    {
        Task<bool> UsuarioTemPermissaoAsync(int usuarioId, string codigoPermissao, CancellationToken cancellationToken);
    }
}
