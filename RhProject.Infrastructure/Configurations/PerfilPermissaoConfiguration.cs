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

            builder
                .HasOne(x => x.Perfil)
                .WithMany()
                .HasForeignKey(x => x.PerfilId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Permissao)
                .WithMany()
                .HasForeignKey(x => x.PermissaoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasIndex(x => new
                {
                    x.PerfilId,
                    x.PermissaoId
                })
                .IsUnique();

            builder.Property(x => x.Ativo)
                .IsRequired();

            builder.Property(x => x.DataCadastro)
                .IsRequired();

            var dataCadastro = new DateTime(2026, 10, 20);

            var permissoes = new[]
            {
                // Administrador
                (Id: 1, Perfil: PerfilEnum.Administrador, Permissao: PermissaoEnum.CooperadoVisualizar),
                (Id: 2, Perfil: PerfilEnum.Administrador, Permissao: PermissaoEnum.CooperadoCriar),
                (Id: 3, Perfil: PerfilEnum.Administrador, Permissao: PermissaoEnum.CooperadoEditar),
                (Id: 4, Perfil: PerfilEnum.Administrador, Permissao: PermissaoEnum.CooperadoExcluir),
                (Id: 5, Perfil: PerfilEnum.Administrador, Permissao: PermissaoEnum.FinanceiroVisualizar),
                (Id: 6, Perfil: PerfilEnum.Administrador, Permissao: PermissaoEnum.FinanceiroGerenciar),
                (Id: 7, Perfil: PerfilEnum.Administrador, Permissao: PermissaoEnum.FeriasVisualizar),
                (Id: 8, Perfil: PerfilEnum.Administrador, Permissao: PermissaoEnum.FeriasAprovar),
                (Id: 9, Perfil: PerfilEnum.Administrador, Permissao: PermissaoEnum.RelatoriosVisualizar),

                // Coordenador
                (Id: 10, Perfil: PerfilEnum.Coordenador, Permissao: PermissaoEnum.CooperadoVisualizar),
                (Id: 11, Perfil: PerfilEnum.Coordenador, Permissao: PermissaoEnum.CooperadoCriar),
                (Id: 12, Perfil: PerfilEnum.Coordenador, Permissao: PermissaoEnum.CooperadoEditar),
                (Id: 13, Perfil: PerfilEnum.Coordenador, Permissao: PermissaoEnum.FeriasVisualizar),
                (Id: 14, Perfil: PerfilEnum.Coordenador, Permissao: PermissaoEnum.FeriasAprovar),
                (Id: 15, Perfil: PerfilEnum.Coordenador, Permissao: PermissaoEnum.RelatoriosVisualizar),

                // Novas permissões de Base
                (Id: 16, Perfil: PerfilEnum.Administrador, Permissao: PermissaoEnum.BaseVisualizar),
                (Id: 17, Perfil: PerfilEnum.Administrador, Permissao: PermissaoEnum.BaseCriar),
                (Id: 18, Perfil: PerfilEnum.Administrador, Permissao: PermissaoEnum.BaseEditar),
                (Id: 19, Perfil: PerfilEnum.Administrador, Permissao: PermissaoEnum.BaseExcluir),

                (Id: 20, Perfil: PerfilEnum.Coordenador, Permissao: PermissaoEnum.BaseVisualizar)
            };

            builder.HasData(
                permissoes.Select(item => new
                {
                    Id = item.Id,
                    PerfilId = (int)item.Perfil,
                    PermissaoId = (int)item.Permissao,
                    Ativo = true,
                    DataCadastro = dataCadastro
                }).ToArray()
            );
        }
    }
}