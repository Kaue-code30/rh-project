using MediatR;
using RhProject.Application.DTOs.Cooperado;
using RhProject.Application.DTOs.Usuario;
using System;
using System.Collections.Generic;
using System.Text;

namespace RhProject.Application.Queries.Usuario.PerfilLogado
{
    public class PerfilUsuarioLogadoQuery : IRequest<PerfilUsuarioLogadoDto>
    {}
}
