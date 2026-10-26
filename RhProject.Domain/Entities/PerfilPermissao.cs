using System;
using System.Collections.Generic;
using System.Text;

namespace RhProject.Domain.Entities
{
    public class PerfilPermissao : BaseEntity
    {

        public int Id { get; set; }
        public int PerfilId { get; set; }
        public int PermissaoId { get; set; }
        public Perfil Perfil { get; set; }
        public Permissao Permissao { get; set; }

    }
}
