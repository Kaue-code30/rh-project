using Microsoft.AspNetCore.Authorization;
using RhProject.Application.Interfaces.Authorization;
using System.Security.Claims;

namespace RhProject.Api.Authorization
{
    public class PermissaoAuthorizationHandler : AuthorizationHandler<PermissaoRequirement>
    {
        private readonly IPermissaoService _permissaoService;

        public PermissaoAuthorizationHandler(IPermissaoService permissaoService)
        {
            _permissaoService = permissaoService;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissaoRequirement requirement)
        {
            var usuarioIdClaim =
                context.User.FindFirst("sub")?.Value
                ?? context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (!int.TryParse(usuarioIdClaim, out var usuarioId))
                return;

            var possuiPermissao = await _permissaoService.UsuarioTemPermissaoAsync(usuarioId, requirement.CodigoPermissao, CancellationToken.None);

            if (possuiPermissao)
                context.Succeed(requirement);
        }
    }
}