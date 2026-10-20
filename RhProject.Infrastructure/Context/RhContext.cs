using Microsoft.EntityFrameworkCore;
using RhProject.Domain.Entities;

namespace RhProject.Infrastructure.Context
{
    public class RhContext : DbContext
    {
        public RhContext(DbContextOptions<RhContext> options) : base(options)
        {}

        public DbSet<Base> Bases { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RhContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}