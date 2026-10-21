using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace RhProject.Application.Commands.Cooperado.AtualizarCooperado
{
    public class AtualizarCooperadoCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public int FuncaoId { get; set; }
        public int BaseId { get; set; }
    }
}
