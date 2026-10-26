using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RhProject.Application.Exceptions;

namespace RhProject.Api.Middlewares
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogError(exception,"Erro durante o processamento da requisição.");

            var statusCode = exception switch
            {
                NotFoundException => StatusCodes.Status404NotFound,

                BusinessException => StatusCodes.Status400BadRequest,

                ConflictException => StatusCodes.Status409Conflict,

                BadRequestException => StatusCodes.Status400BadRequest,

                _ => StatusCodes.Status500InternalServerError
            };

            var problem = new ProblemDetails
            {
                Status = statusCode,

                Title = statusCode switch
                {
                    400 => "Requisição inválida",
                    404 => "Recurso não encontrado",
                    409 => "Conflito",
                    _ => "Erro interno"
                },

                Detail = statusCode == 500 ? "Ocorreu um erro interno no servidor." : exception.Message
            };

            httpContext.Response.StatusCode = statusCode;

            await httpContext.Response.WriteAsJsonAsync(problem, cancellationToken);

            return true;
        }
    }
}