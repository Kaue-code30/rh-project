using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace RhProject.Application.Commands.Base.ExcluirBase
{
    public class ExcluirBaseCommandValidator : AbstractValidator<ExcluirBaseCommand>
    {
        public ExcluirBaseCommandValidator()
        {   

            RuleFor(b => b.Id)
                .GreaterThan(0).WithMessage("O Id da base deve ser maior que zero.");
        }
    }
}
