using MediatR;
using Microsoft.AspNetCore.Mvc;
using RhProject.Application.Commands.Base.CriarBase;

namespace RhProject.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarBaseCommand command,CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command,cancellationToken);

            return Ok(id);
        }
    }
}