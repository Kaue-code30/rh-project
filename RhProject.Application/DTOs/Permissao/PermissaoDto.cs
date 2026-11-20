using RhProject.Application.DTOs.Funcao;
using RhProject.Domain.Entities;

namespace RhProject.Application.DTOs.Cooperado
{
    public class PermissaoDto
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string Modulo { get; set; } = string.Empty;

    }
}