using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace RhProject.Application.Commands.Cooperado.CriarUsuario
{
    public class CriarUsuarioCommand : IRequest<int>
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public int PerfilId { get; set; }
    }
}
