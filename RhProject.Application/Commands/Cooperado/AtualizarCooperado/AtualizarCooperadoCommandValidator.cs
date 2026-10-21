using FluentValidation;
using RhProject.Domain.Validators;

namespace RhProject.Application.Commands.Cooperado.AtualizarCooperado
{
    public class AtualizarCooperadoCommandValidator
        : AbstractValidator<AtualizarCooperadoCommand>
    {
        public AtualizarCooperadoCommandValidator()
        {
            RuleFor(c => c.Nome)
                .NotEmpty()
                    .WithMessage("O nome do cooperado é obrigatório.")
                .MaximumLength(150)
                    .WithMessage("O nome do cooperado não pode exceder 150 caracteres.");

            RuleFor(c => c.Telefone)
                .MaximumLength(20)
                    .WithMessage("O telefone do cooperado não pode exceder 20 caracteres.");

            RuleFor(c => c.Email)
                .NotEmpty()
                    .WithMessage("O email do cooperado é obrigatório.")
                .MaximumLength(100)
                    .WithMessage("O email do cooperado não pode exceder 100 caracteres.")
                .EmailAddress()
                    .WithMessage("O email informado é inválido.");            

            RuleFor(c => c.FuncaoId)
                .GreaterThan(0)
                    .WithMessage("A função do cooperado é obrigatória.");

            RuleFor(c => c.BaseId)
                .GreaterThan(0)
                    .WithMessage("A base do cooperado é obrigatória.");
        }
    }
}