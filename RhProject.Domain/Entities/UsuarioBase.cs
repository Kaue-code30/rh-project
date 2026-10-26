namespace RhProject.Domain.Entities
{
    public class UsuarioBase : BaseEntity
    {
        protected UsuarioBase() { }

        public UsuarioBase(
            int usuarioId,
            int baseId)
        {
            UsuarioId = usuarioId;
            BaseId = baseId;
        }

        public int UsuarioId { get; private set; }
        public Usuario Usuario { get; private set; }

        public int BaseId { get; private set; }
        public Base Base { get; private set; }
    }
}