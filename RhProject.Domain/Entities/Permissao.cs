using System;
using System.Collections.Generic;
using System.Text;

namespace RhProject.Domain.Entities
{
    public class Permissao : BaseEntity
    {

        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string Modulo { get; set; }

    }
}
