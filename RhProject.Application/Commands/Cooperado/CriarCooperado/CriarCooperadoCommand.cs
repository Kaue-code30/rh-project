using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace RhProject.Application.Commands.Base.CriarBase
{
    public class CriarCooperadoCommand : IRequest<int>
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public DateTime DataInicio { get; set; }
        public int FuncaoId { get; set; }
    }
}
