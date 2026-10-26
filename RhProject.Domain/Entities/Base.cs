using System;
using System.Collections.Generic;
using System.Text;

namespace RhProject.Domain.Entities
{
    public class Base : BaseEntity
    {

        public Base(string nome, string? descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }

        public string Nome { get; private set; }
        public string? Descricao { get; private set; }

        public ICollection<UsuarioBase> UsuariosBases { get; private set; } = new List<UsuarioBase>();

        //#region Métodos
        public void AtualizarNome(string nome)
        {
            Nome = nome;
        }
        public void AtualizarDescricao(string? descricao)
        {
            Descricao = descricao;
        }

        public void Atualizar(string nome, string? descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }
    }
}
