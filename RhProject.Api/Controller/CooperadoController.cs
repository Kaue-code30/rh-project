using MediatR;
using Microsoft.AspNetCore.Mvc;
using RhProject.Application.Commands.Base.CriarBase;
using RhProject.Application.Queries.Cooperado.Listar;

namespace RhProject.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CooperadoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CooperadoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarCooperadoCommand command,CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command,cancellationToken);

            return Ok(id);
        }

        [HttpGet("listar")]
        public async Task<IActionResult> Listar(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new ListarCooperadosQuery(), cancellationToken);

            return Ok(result);
        }

        [HttpGet("listarPorFuncao/{funcaoId}")]
        public async Task<IActionResult> ListarPorFuncao(int funcaoId, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new ListarCooperadosPorFuncaoQuery { FuncaoId = funcaoId }, cancellationToken);

            return Ok(result);
        }
    }
}