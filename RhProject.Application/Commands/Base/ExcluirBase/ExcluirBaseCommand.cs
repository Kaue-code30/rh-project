using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace RhProject.Application.Commands.Base.ExcluirBase
{
    public class ExcluirBaseCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
