using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace RhProject.Application.Commands.Base.CriarBase
{
    public class CriarBaseCommand : IRequest<int>
    {
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; } = string.Empty;
    }
}
