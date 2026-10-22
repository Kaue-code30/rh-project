using System;
using System.Collections.Generic;
using System.Text;

namespace RhProject.Domain.Entities
{
    public class Cooperado : BaseEntity
    {
        public Cooperado(string nome, string email, string cpf, string telefone, DateTime dataNascimento, DateTime dataInicio, int funcaoId, int baseId)
        {
            Nome = nome;
            Email = email;
            Cpf = cpf;
            Telefone = telefone;
            DataNascimento = dataNascimento;
            DataInicio = dataInicio;
            FuncaoId = funcaoId;
            BaseId = baseId;
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }
        public string Telefone { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public DateTime DataInicio { get; private set; }
        public int FuncaoId { get; private set; }
        public int BaseId { get; private set; }
        public Funcao Funcao { get; private set; }
        public Base Base { get; private set; }



        public void AtualizarNome(string nome)
        {
            Nome = nome;
        }
        public void AtualizarEmail(string email)
        {
            Email = email;
        }
        public void AtualizarTelefone(string telefone)
        {
            Telefone = telefone;
        }
        public void AtualizarFuncao(Funcao funcao)
        {
            Funcao = funcao;
            FuncaoId = funcao.Id;
        }

        public void AtualizarBase(Base baseEmp)
        {
            Base = baseEmp;
            BaseId = baseEmp.Id;

        }

        public void Atualizar(string nome, string email, string telefone, int funcaoId, Base baseEmp)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            FuncaoId = funcaoId;
            Base = baseEmp;
            BaseId = baseEmp.Id;
        }
    }
}
