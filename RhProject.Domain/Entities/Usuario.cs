using System;
using System.Collections.Generic;
using System.Text;

namespace RhProject.Domain.Entities
{
    public class Usuario : BaseEntity
    {

        private Usuario() { }

        public Usuario(string nome, string email, string senhaHash, int? cooperadoId = null)
        {
            Nome = nome;
            Email = email;
            SenhaHash = senhaHash;
            CooperadoId = cooperadoId;
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string SenhaHash { get; private set; }
        public int? CooperadoId { get; private set; }
        public Cooperado? Cooperado { get; private set; }

        public ICollection<UsuarioBase> UsuarioBases { get; private set; } = new List<UsuarioBase>();

        public void AlterarSenha(string novoHash)
        {
            SenhaHash = novoHash;
        }

        public void AlterarNome(string novoNome)
        {
            Nome = novoNome;
        }

        public void AlterarEmail(string novoEmail)
        {
            Email = novoEmail;
        }
    }
}
