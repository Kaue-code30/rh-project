using RhProject.Application.DTOs.Funcao;
using RhProject.Domain.Entities;

namespace RhProject.Application.DTOs.Cooperado
{
    public class CooperadoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public DateTime DataInicio { get; set; }
        public int FuncaoId { get; set; }
        public int BaseId { get; set; }
        public FuncaoDto Funcao { get; set; } = new();
    }
}