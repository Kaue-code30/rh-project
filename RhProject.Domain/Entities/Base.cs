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


        //#region Métodos
        public void AtualizarNome(string nome)
        {
            Nome = nome;
        }
        public void AtualizarDescricao(string? descricao)
        {
            Descricao = descricao;
        }
    }
}
