using RhProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RhProject.Domain.Entities
{
    public class Funcao : BaseEntity
    {

        protected Funcao()
        {
        }

        public Funcao(FuncaoEnum tipo)
        {
            Id = (int)tipo;
            Descricao = tipo.ToString();
        }

        public string Descricao { get; private set; }

    }
}
