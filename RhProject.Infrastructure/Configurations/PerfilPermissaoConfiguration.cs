using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RhProject.Domain.Entities;

namespace RhProject.Infrastructure.Configurations
{
    public class PerfilPermissaoConfiguration : IEntityTypeConfiguration<PerfilPermissao>
    {
        public void Configure(EntityTypeBuilder<PerfilPermissao> builder)
        {
            builder.ToTable("PerfilPermissao");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Perfil).WithMany().HasForeignKey(x => x.PerfilId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Permissao).WithMany().HasForeignKey(x => x.PermissaoId).OnDelete(DeleteBehavior.Restrict);
            builder.Property(x => x.Ativo).IsRequired();
            builder.Property(x => x.DataCadastro).IsRequired();
        }
    }
}