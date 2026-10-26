using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RhProject.Application.Commands.Base.AtualizarBase;
using RhProject.Application.Commands.Base.CriarBase;
using RhProject.Application.Commands.Base.ExcluirBase;
using RhProject.Application.Queries.Base.Listar;
using RhProject.Domain.Enums;

namespace RhProject.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Policy = nameof(PermissaoEnum.BaseCriar))]
        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarBaseCommand command,CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command,cancellationToken);

            return Ok(id);
        }

        [Authorize(Policy = nameof(PermissaoEnum.BaseEditar))]
        [HttpPut]
        public async Task<IActionResult> Atualizar([FromBody] AtualizarBaseCommand command,CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(command,cancellationToken);

            return Ok(response);
        }

        [Authorize(Policy = nameof(PermissaoEnum.BaseExcluir))]
        [HttpDelete]
        public async Task<IActionResult> Remover([FromBody] ExcluirBaseCommand command,CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(command,cancellationToken);

            return Ok(response);
        }

        [Authorize(Policy = nameof(PermissaoEnum.BaseVisualizar))]
        [HttpGet]
        public async Task<IActionResult> Listar(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new ListarBasesQuery(), cancellationToken);

            return Ok(result);
        }
    }
}