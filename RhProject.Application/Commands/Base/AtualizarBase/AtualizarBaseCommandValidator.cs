using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace RhProject.Application.Commands.Base.AtualizarBase
{
    public class AtualizarBaseCommandValidator : AbstractValidator<AtualizarBaseCommand>
    {
        public AtualizarBaseCommandValidator()
        {   

            RuleFor(b => b.Id)
                .GreaterThan(0).WithMessage("O Id da base deve ser maior que zero.");

            RuleFor(b => b.Nome)
                .NotEmpty().WithMessage("O nome da base é obrigatório.")
                .MaximumLength(100).WithMessage("O nome da base não pode exceder 100 caracteres.");

            RuleFor(b => b.Descricao)
                .MaximumLength(300).WithMessage("A descrição da base não pode exceder 300 caracteres.");
        }
    }
}
