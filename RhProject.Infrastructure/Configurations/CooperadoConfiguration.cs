using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RhProject.Domain.Entities;

namespace RhProject.Infrastructure.Configurations
{
    public class CooperadoConfiguration : IEntityTypeConfiguration<Cooperado>
    {
        public void Configure(EntityTypeBuilder<Cooperado> builder)
        {
            builder.ToTable("Cooperados");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Cpf).HasColumnType("varchar(11)").HasMaxLength(11).IsRequired();
            builder.Property(x => x.Telefone).HasMaxLength(20);
            builder.Property(x => x.DataNascimento).IsRequired();
            builder.Property(x => x.DataInicio).IsRequired();
            builder.HasOne(x => x.Funcao).WithMany().HasForeignKey(x => x.FuncaoId).OnDelete(DeleteBehavior.Restrict);
            builder.Property(x => x.Ativo).IsRequired();
            builder.Property(x => x.DataCadastro).IsRequired();
        }
    }
}