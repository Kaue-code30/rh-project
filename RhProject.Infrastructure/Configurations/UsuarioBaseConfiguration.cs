using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RhProject.Domain.Entities;

namespace RhProject.Infrastructure.Configurations
{
    public class UsuarioBaseConfiguration
        : IEntityTypeConfiguration<UsuarioBase>
    {
        public void Configure(
            EntityTypeBuilder<UsuarioBase> builder)
        {
            builder.ToTable("UsuarioBase");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.UsuarioId)
                .IsRequired();

            builder.Property(x => x.BaseId)
                .IsRequired();

            builder.Property(x => x.Ativo)
                .IsRequired();

            builder.Property(x => x.DataCadastro)
                .IsRequired();

            builder
                .HasOne(x => x.Usuario)
                .WithMany(x => x.UsuarioBases)
                .HasForeignKey(x => x.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Base)
                .WithMany(x => x.UsuariosBases)
                .HasForeignKey(x => x.BaseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasIndex(x => new
                {
                    x.UsuarioId,
                    x.BaseId
                })
                .IsUnique();
        }
    }
}