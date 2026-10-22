using MediatR;
using RhProject.Application.DTOs;
using RhProject.Application.DTOs.Cooperado;

namespace RhProject.Application.Queries.Cooperado.Listar
{
    public class ListarCooperadosPorBaseQuery : IRequest<List<CooperadoDto>>
    {
        public int BaseId { get; set; }
    }
}