using MediatR;
using RhProject.Application.DTOs;
using RhProject.Application.DTOs.Cooperado;

namespace RhProject.Application.Queries.Cooperado.Listar
{
    public class ListarCooperadosQuery : IRequest<List<CooperadoDto>>
    {
    }
}