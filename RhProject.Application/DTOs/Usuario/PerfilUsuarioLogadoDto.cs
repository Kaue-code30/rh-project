using RhProject.Application.DTOs.Cooperado;
using RhProject.Application.DTOs.Funcao;

namespace RhProject.Application.DTOs.Usuario
{
    public class PerfilUsuarioLogadoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string TipoUsuarioDescricao { get; set; } = string.Empty;
        public List<FuncaoDto>? Funcoes { get; set; } = new List<FuncaoDto>();
        public List<PermissaoDto>? Permissoes { get; set; } = new List<PermissaoDto>();
    }
}