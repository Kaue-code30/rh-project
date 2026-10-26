using RhProject.Domain.Extensions;

namespace RhProject.Domain.Entities
{
    public class Perfil : BaseEntity
    {

        protected Perfil()
        {
        }

        public Perfil(PerfilEnum perfil)
        {
            Id = (int)perfil;
            Nome = perfil.ToString();
            Descricao = perfil.GetDescription();
        }

        public string Nome { get; private set; }
        public string Descricao { get; private set; }

    }
}
