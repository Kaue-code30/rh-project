using FluentValidation;
using RhProject.Application.Commands.Cooperado.ExcluirCooperado;

namespace RhProject.Application.Commands.Base.ExcluirCooperado
{
    public class ExcluirCooperadoCommandValidator : AbstractValidator<ExcluirCooperadoCommand>
    {
        public ExcluirCooperadoCommandValidator()
        {
            RuleFor(c => c.CooperadosIds)
                .NotEmpty()
                .WithMessage("É obrigatório informar ao menos um cooperado.");
            RuleForEach(c => c.CooperadosIds)
                .GreaterThan(0)
                .WithMessage("O ID do cooperado deve ser maior que zero.");
        }
    }
}
                