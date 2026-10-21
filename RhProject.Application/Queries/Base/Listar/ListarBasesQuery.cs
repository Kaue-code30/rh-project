using MediatR;

namespace RhProject.Application.Queries.Base.Listar
{
    public class ListarBasesQuery : IRequest<List<DTOs.Base.BaseDto>>
    {
    }
}