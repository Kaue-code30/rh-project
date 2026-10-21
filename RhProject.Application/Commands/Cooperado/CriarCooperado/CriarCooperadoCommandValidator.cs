using FluentValidation;
using RhProject.Domain.Validators;

namespace RhProject.Application.Commands.Base.CriarBase
{
    public class CriarCooperadoCommandValidator
        : AbstractValidator<CriarCooperadoCommand>
    {
        public CriarCooperadoCommandValidator()
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

            RuleFor(c => c.Cpf)
                .NotEmpty()
                    .WithMessage("O CPF do cooperado é obrigatório.")
                .Length(11)
                    .WithMessage("O CPF do cooperado deve possuir 11 caracteres.")
                .Must(CpfValidator.EhValido)
                    .WithMessage("O CPF informado é inválido.");

            RuleFor(c => c.DataNascimento)
                .NotEmpty()
                    .WithMessage("A data de nascimento do cooperado é obrigatória.")
                .LessThan(DateTime.Today)
                    .WithMessage("A data de nascimento deve ser anterior à data atual.");

            RuleFor(c => c.DataInicio)
                .NotEmpty()
                    .WithMessage("A data de início do cooperado é obrigatória.")
                .LessThanOrEqualTo(DateTime.Today)
                    .WithMessage("A data de início não pode ser posterior à data atual.");

            RuleFor(c => c.FuncaoId)
                .GreaterThan(0)
                    .WithMessage("A função do cooperado é obrigatória.");

            RuleFor(c => c.BaseId)
                .GreaterThan(0)
                    .WithMessage("A base do cooperado é obrigatória.");
        }
    }
}