using Microsoft.AspNetCore.Authorization;

namespace RhProject.Api.Authorization
{
    public class PermissaoRequirement : IAuthorizationRequirement
    {
        public string CodigoPermissao { get; }

        public PermissaoRequirement(string codigoPermissao)
        {
            CodigoPermissao = codigoPermissao;
        }
    }
}