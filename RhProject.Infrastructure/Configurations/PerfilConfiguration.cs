using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RhProject.Domain.Entities;
using RhProject.Domain.Enums;
using RhProject.Domain.Extensions;

namespace RhProject.Infrastructure.Configurations
{
    public class PerfilConfiguration : IEntityTypeConfiguration<Perfil>
    {
        public void Configure(EntityTypeBuilder<Perfil> builder)
        {
            builder.ToTable("Perfil");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.Descricao)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Ativo)
                .IsRequired();

            builder.Property(x => x.DataCadastro)
                .IsRequired();

            builder.HasData(
                new
                {
                    Id = (int)PerfilEnum.Administrador,
                    Nome = PerfilEnum.Administrador.ToString(),
                    Descricao = PerfilEnum.Administrador.GetDescription(),
                    Ativo = true,
                    DataCadastro = new DateTime(2026, 10, 20)
                },
                new
                {
                    Id = (int)PerfilEnum.Coordenador,
                    Nome = PerfilEnum.Coordenador.ToString(),
                    Descricao = PerfilEnum.Coordenador.GetDescription(),
                    Ativo = true,
                    DataCadastro = new DateTime(2026, 10, 20)
                },
                new
                {
                    Id = (int)PerfilEnum.Cooperado,
                    Nome = PerfilEnum.Cooperado.ToString(),
                    Descricao = PerfilEnum.Cooperado.GetDescription(),
                    Ativo = true,
                    DataCadastro = new DateTime(2026, 10, 20)
                },
                new
                {
                    Id = (int)PerfilEnum.Personalizado,
                    Nome = PerfilEnum.Personalizado.ToString(),
                    Descricao = PerfilEnum.Personalizado.GetDescription(),
                    Ativo = true,
                    DataCadastro = new DateTime(2026, 10, 20)
                }
            );
        }
    }
}