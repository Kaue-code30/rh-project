using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace RhProject.Application.Commands.Base.CriarBase
{
    public class CriarCooperadoCommandValidator : AbstractValidator<CriarCooperadoCommand>
    {
        public CriarCooperadoCommandValidator()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O nome do cooperado é obrigatório.")
                .MaximumLength(100).WithMessage("O nome do cooperado não pode exceder 100 caracteres.");

            RuleFor(c => c.Telefone)
                .MaximumLength(20).WithMessage("O telefone do cooperado não pode exceder 20 caracteres.");
            
            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("O email do cooperado é obrigatório.")
                .MaximumLength(100).WithMessage("O email do cooperado não pode exceder 100 caracteres.");

            RuleFor(c => c.Cpf)
                .NotEmpty().WithMessage("O CPF do cooperado é obrigatório.")
                .MaximumLength(11).WithMessage("O CPF do cooperado não pode exceder 11 caracteres.");

            RuleFor(c => c.DataNascimento)
                .NotEmpty().WithMessage("A data de nascimento do cooperado é obrigatória.")
                .LessThan(DateTime.Now).WithMessage("A data de nascimento do cooperado deve ser anterior à data atual.");

            RuleFor(c => c.DataInicio)
                .NotEmpty().WithMessage("A data de início do cooperado é obrigatória.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("A data de início do cooperado não pode ser posterior à data atual.");

            RuleFor(c => c.FuncaoId)
                .GreaterThan(0).WithMessage("O ID da função do cooperado deve ser maior que zero.");
        }
    }
}
