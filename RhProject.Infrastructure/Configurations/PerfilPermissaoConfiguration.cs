using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RhProject.Domain.Entities;
using RhProject.Domain.Enums;

namespace RhProject.Infrastructure.Configurations
{
    public class PerfilPermissaoConfiguration
        : IEntityTypeConfiguration<PerfilPermissao>
    {
        public void Configure(EntityTypeBuilder<PerfilPermissao> builder)
        {
            builder.ToTable("PerfilPermissao");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Perfil).WithMany().HasForeignKey(x => x.PerfilId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Permissao).WithMany().HasForeignKey(x => x.PermissaoId).OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => new
            {
                x.PerfilId,
                x.PermissaoId
            }).IsUnique();

            builder.Property(x => x.Ativo).IsRequired();

            builder.Property(x => x.DataCadastro).IsRequired();

            var dataCadastro = new DateTime(2026, 10, 20);

            var permissoes = new[]
            {
                // Administrador
                (PerfilEnum.Administrador, PermissaoEnum.CooperadoVisualizar),
                (PerfilEnum.Administrador, PermissaoEnum.CooperadoCriar),
                (PerfilEnum.Administrador, PermissaoEnum.CooperadoEditar),
                (PerfilEnum.Administrador, PermissaoEnum.CooperadoExcluir),
                (PerfilEnum.Administrador, PermissaoEnum.FinanceiroVisualizar),
                (PerfilEnum.Administrador, PermissaoEnum.FinanceiroGerenciar),
                (PerfilEnum.Administrador, PermissaoEnum.FeriasVisualizar),
                (PerfilEnum.Administrador, PermissaoEnum.FeriasAprovar),
                (PerfilEnum.Administrador, PermissaoEnum.RelatoriosVisualizar),

                // Coordenador
                (PerfilEnum.Coordenador, PermissaoEnum.CooperadoVisualizar),
                (PerfilEnum.Coordenador, PermissaoEnum.CooperadoCriar),
                (PerfilEnum.Coordenador, PermissaoEnum.CooperadoEditar),
                (PerfilEnum.Coordenador, PermissaoEnum.FeriasVisualizar),
                (PerfilEnum.Coordenador, PermissaoEnum.FeriasAprovar)
            };

            builder.HasData(
                permissoes.Select((item, index) => new
                {
                    Id = index + 1,
                    PerfilId = (int)item.Item1,
                    PermissaoId = (int)item.Item2,
                    Ativo = true,
                    DataCadastro = dataCadastro
                }).ToArray()
            );
        }
    }
}