

using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RhProject.Application.Commands.Cooperado.CriarUsuario;
using System.IdentityModel.Tokens.Jwt;

namespace RhProject.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarUsuarioCommand command, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);

            return Ok(id);
        }

        [HttpPost("cooperado")]
        [Authorize]
        public async Task<IActionResult> CriarUsuarioCooperado([FromBody] CriarUsuarioCooperadoCommand command, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);

            return Ok(id);
        }

        [HttpGet("me")]
        [Authorize]
        public IActionResult Me()
        {
            var usuarioId = User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;

            var email = User.FindFirst(JwtRegisteredClaimNames.Email)?.Value;

            return Ok(new
            {
                UsuarioId = usuarioId,
                Email = email
            });
        }


    }
}