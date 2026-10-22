using MediatR;
using RhProject.Application.DTOs;
using RhProject.Application.DTOs.Cooperado;

namespace RhProject.Application.Queries.Cooperado.Listar
{
    public class ListarCooperadosPorFuncaoQuery : IRequest<List<CooperadoDto>>
    {
        public int FuncaoId { get; set; }
    }
}