using System;
using System.Collections.Generic;
using System.Text;

namespace RhProject.Domain.Entities
{
    public class UsuarioPerfil : BaseEntity
    {
        public UsuarioPerfil(int usuarioId, int perfilId, int? baseId)
        {
            UsuarioId = usuarioId;
            PerfilId = perfilId;
            BaseId = baseId;
        }

        public int UsuarioId { get; private set; }
        public int PerfilId { get; private set; }
        public int? BaseId { get; private set; }

        public Usuario Usuario{ get; private set; }
        public Perfil Perfil { get; private set; }
        public Base Base { get; private set; }

    }
}
