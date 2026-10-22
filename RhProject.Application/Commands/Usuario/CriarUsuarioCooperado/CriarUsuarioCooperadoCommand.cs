using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace RhProject.Application.Commands.Cooperado.CriarUsuario
{
    public class CriarUsuarioCooperadoCommand : IRequest<int>
    {
        public string Senha { get; set; }
        public int CooperadoId { get; set; }
    }
}
