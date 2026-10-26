using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RhProject.Domain.Entities;
using RhProject.Domain.Enums;

namespace RhProject.Infrastructure.Configurations
{
    public class FuncaoConfiguration : IEntityTypeConfiguration<Funcao>
    {
        public void Configure(EntityTypeBuilder<Funcao> builder)
        {
            builder.ToTable("Funcao");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descricao)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.Ativo)
                .IsRequired();

            builder.Property(x => x.DataCadastro)
                .IsRequired();

            builder.HasData(
                new
                {
                    Id = (int)FuncaoEnum.Medico,
                    Descricao = FuncaoEnum.Medico.ToString(),
                    Ativo = true,
                    DataCadastro = new DateTime(2026, 10, 20)
                },
                new
                {
                    Id = (int)FuncaoEnum.Enfermeiro,
                    Descricao = FuncaoEnum.Enfermeiro.ToString(),
                    Ativo = true,
                    DataCadastro = new DateTime(2026, 10, 20)
                },
                new
                {
                    Id = (int)FuncaoEnum.TecnicoEnfermagem,
                    Descricao = FuncaoEnum.TecnicoEnfermagem.ToString(),
                    Ativo = true,
                    DataCadastro = new DateTime(2026, 10, 20)
                }
            );
        }
    }
}