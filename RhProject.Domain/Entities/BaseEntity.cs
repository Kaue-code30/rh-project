namespace RhProject.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; protected set; }
        public bool Ativo { get; protected set; }
        public DateTime DataCadastro { get; protected set; }

        protected BaseEntity()
        {
            Ativo = true;
            DataCadastro = DateTime.Now;
        }
    }
}