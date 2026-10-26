using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RhProject.Domain.Entities;
using RhProject.Domain.Enums;
using RhProject.Domain.Extensions;

namespace RhProject.Infrastructure.Configurations
{
    public class PermissaoConfiguration : IEntityTypeConfiguration<Permissao>
    {
        public void Configure(EntityTypeBuilder<Permissao> builder)
        {
            builder.ToTable("Permissao");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Codigo)
                .HasMaxLength(150)
                .IsRequired();

            builder.HasIndex(x => x.Codigo)
                .IsUnique();

            builder.Property(x => x.Descricao)
                .HasMaxLength(500);

            builder.Property(x => x.Modulo)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Ativo)
                .IsRequired();

            builder.Property(x => x.DataCadastro)
                .IsRequired();

            var dataCadastro = new DateTime(2026, 10, 20);

            builder.HasData(
                Enum.GetValues<PermissaoEnum>()
                    .Select(permissao => new
                    {
                        Id = (int)permissao,
                        Codigo = permissao.ToString(),
                        Descricao = permissao.GetDescription(),
                        Modulo = ObterModulo(permissao),
                        Ativo = true,
                        DataCadastro = dataCadastro
                    })
                    .ToArray()
            );
        }

        private static string ObterModulo(PermissaoEnum permissao)
        {
            return permissao switch
            {
                PermissaoEnum.CooperadoVisualizar
                    or PermissaoEnum.CooperadoCriar
                    or PermissaoEnum.CooperadoEditar
                    or PermissaoEnum.CooperadoExcluir
                    => "Cooperados",

                PermissaoEnum.FinanceiroVisualizar
                    or PermissaoEnum.FinanceiroGerenciar
                    => "Financeiro",

                PermissaoEnum.FeriasVisualizar
                    or PermissaoEnum.FeriasAprovar
                    => "Ferias",

                PermissaoEnum.RelatoriosVisualizar
                    => "Relatorios",

                PermissaoEnum.BaseVisualizar
                    or PermissaoEnum.BaseCriar
                    or PermissaoEnum.BaseEditar
                    or PermissaoEnum.BaseExcluir
                    => "Base",

                _ => throw new ArgumentOutOfRangeException(
                    nameof(permissao),
                    permissao,
                    "Permissão sem módulo configurado.")
            };
        }
    }
}