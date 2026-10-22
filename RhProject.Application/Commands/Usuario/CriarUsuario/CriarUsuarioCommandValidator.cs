using FluentValidation;
using RhProject.Application.Commands.Cooperado.CriarUsuario;

namespace RhProject.Application.Commands.Usuario.CriarUsuario
{
    public class CriarUsuarioCommandValidator : AbstractValidator<CriarUsuarioCommand>
    {
        public CriarUsuarioCommandValidator()
        {
            RuleFor(c => c.Nome)
                .NotEmpty()
                    .WithMessage("O nome do usuário é obrigatório.")
                .MaximumLength(150)
                    .WithMessage("O nome do usuário não pode exceder 150 caracteres.");

            RuleFor(c => c.Email)
                .NotEmpty()
                    .WithMessage("O email do usuário é obrigatório.")
                .MaximumLength(100)
                    .WithMessage("O email do usuário não pode exceder 100 caracteres.")
                .EmailAddress()
                    .WithMessage("O email informado é inválido.");

            RuleFor(c => c.Senha)
                .NotEmpty()
                    .WithMessage("A senha é obrigatória.")
                .MinimumLength(12)
                    .WithMessage("A senha deve possuir pelo menos 12 caracteres.")
                .MaximumLength(128)
                    .WithMessage("A senha não pode exceder 128 caracteres.");

            RuleFor(c => c.CooperadoId)
                .GreaterThan(0)
                    .When(c => c.CooperadoId.HasValue)
                    .WithMessage("O cooperado informado é inválido.");
        }
    }
}