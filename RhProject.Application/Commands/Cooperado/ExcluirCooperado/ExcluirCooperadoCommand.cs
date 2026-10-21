using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace RhProject.Application.Commands.Cooperado.ExcluirCooperado
{
    public class ExcluirCooperadoCommand : IRequest<Unit>
    {
        public List<int> CooperadosIds { get; set; } = [];
    }
}
