using FluentValidation;
using RhProject.Application.Commands.Cooperado.CriarUsuario;

namespace RhProject.Application.Commands.Usuario.CriarUsuario
{
    public class CriarUsuarioCooperadoCommandValidator : AbstractValidator<CriarUsuarioCooperadoCommand>
    {
        public CriarUsuarioCooperadoCommandValidator()
        {

            RuleFor(c => c.Senha)
                .NotEmpty()
                    .WithMessage("A senha é obrigatória.")
                .MinimumLength(12)
                    .WithMessage("A senha deve possuir pelo menos 12 caracteres.")
                .MaximumLength(128)
                    .WithMessage("A senha não pode exceder 128 caracteres.");

            RuleFor(c => c.CooperadoId)
                .GreaterThan(0)
                    .WithMessage("O cooperado informado é inválido.");
        }
    }
}