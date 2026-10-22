using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace RhProject.Application.Commands.Auth.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(c => c.Email)
                .NotEmpty()
                    .WithMessage("O email é obrigatório.")
                .MaximumLength(100)
                    .WithMessage("O email não pode exceder 100 caracteres.")
                .EmailAddress()
                    .WithMessage("O email informado é inválido.");
            RuleFor(c => c.Senha)
                .NotEmpty()
                    .WithMessage("A senha é obrigatória.");             
        }
    }
}
