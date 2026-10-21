using FluentValidation;
using MediatR;
using RhProject.Application.Exceptions;

namespace RhProject.Application.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(
            IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            if (!_validators.Any())
                return await next();

            var context = new ValidationContext<TRequest>(request);

            var results = await Task.WhenAll(
                _validators.Select(x =>
                    x.ValidateAsync(context, cancellationToken)));

            var failures = results
                .SelectMany(x => x.Errors)
                .Where(x => x != null)
                .ToList();

            if (failures.Count != 0)
            {
                var mensagens = failures
                    .Select(x => x.ErrorMessage);

                throw new BadRequestException(
                    string.Join(" | ", mensagens));
            }

            return await next();
        }
    }
}