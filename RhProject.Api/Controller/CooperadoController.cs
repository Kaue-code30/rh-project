using MediatR;
using Microsoft.AspNetCore.Mvc;
using RhProject.Application.Commands.Cooperado.AtualizarCooperado;
using RhProject.Application.Commands.Cooperado.CriarCooperado;
using RhProject.Application.Commands.Cooperado.ExcluirCooperado;
using RhProject.Application.Queries.Cooperado.Listar;
using Microsoft.AspNetCore.Authorization;

namespace RhProject.Api.Controllers
{
    [ApiController]
    [Authorize]
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

        [HttpPut]
        public async Task<IActionResult> Atualizar([FromBody] AtualizarCooperadoCommand command, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(command,cancellationToken);

            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Deletar([FromBody] ExcluirCooperadoCommand command,CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(response);
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

        [HttpGet("listarPorBase/{baseId}")]
        public async Task<IActionResult> ListarPorBase(int baseId, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new ListarCooperadosPorBaseQuery { BaseId = baseId }, cancellationToken);

            return Ok(result);
        }
    }
}