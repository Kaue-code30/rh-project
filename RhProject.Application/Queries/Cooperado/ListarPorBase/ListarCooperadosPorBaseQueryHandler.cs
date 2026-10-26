using MediatR;
using RhProject.Application.DTOs.Cooperado;
using RhProject.Application.DTOs.Funcao;
using RhProject.Application.Exceptions;
using RhProject.Application.Interfaces.Authorization;
using RhProject.Domain.Interfaces.Repository;

namespace RhProject.Application.Queries.Cooperado.Listar
{
    public class ListarCooperadosPorBaseQueryHandler
        : IRequestHandler<ListarCooperadosPorBaseQuery, List<CooperadoDto>>
    {
        private readonly ICooperadoRepository _cooperadoRepository;
        private readonly IUsuarioBaseRepository _usuarioBaseRepository;
        private readonly IUsuarioLogadoService _usuarioLogadoService;

        public ListarCooperadosPorBaseQueryHandler(
            ICooperadoRepository cooperadoRepository,
            IUsuarioBaseRepository usuarioBaseRepository,
            IUsuarioLogadoService usuarioLogadoService)
        {
            _cooperadoRepository = cooperadoRepository;
            _usuarioBaseRepository = usuarioBaseRepository;
            _usuarioLogadoService = usuarioLogadoService;
        }

        public async Task<List<CooperadoDto>> Handle(
            ListarCooperadosPorBaseQuery request,
            CancellationToken cancellationToken)
        {
            if (request.BaseId <= 0)
                throw new BadRequestException("Informe uma base válida.");

            var usuarioId = _usuarioLogadoService.ObterUsuarioId();

            var usuarioEhAdministrador =
                await _usuarioLogadoService
                    .EhAdministradorAsync(cancellationToken);

            var usuarioEhCoordenador =
                await _usuarioLogadoService
                    .EhCoordenadorAsync(cancellationToken);

            if (!usuarioEhAdministrador && !usuarioEhCoordenador)
            {
                throw new UnauthorizedAccessException(
                    "Acesso negado. O usuário não possui permissão para listar cooperados por base.");
            }

            if (usuarioEhCoordenador && !usuarioEhAdministrador)
            {
                var possuiAcessoBase =
                    await _usuarioBaseRepository.UsuarioPossuiBaseAsync(
                        usuarioId,
                        request.BaseId,
                        cancellationToken);

                if (!possuiAcessoBase)
                {
                    throw new UnauthorizedAccessException(
                        "O coordenador não possui acesso a esta base.");
                }
            }

            var cooperados =
                await _cooperadoRepository.ObterPorBaseAsync(
                    request.BaseId,
                    cancellationToken);

            return cooperados.Select(x => new CooperadoDto
            {
                Id = x.Id,
                Nome = x.Nome,
                Email = x.Email,
                Cpf = x.Cpf,
                Telefone = x.Telefone,
                DataNascimento = x.DataNascimento,
                DataInicio = x.DataInicio,
                FuncaoId = x.FuncaoId,
                BaseId = x.BaseId,

                Funcao = new FuncaoDto
                {
                    Id = x.Funcao!.Id,
                    Descricao = x.Funcao.Descricao
                }
            }).ToList();
        }
    }
}