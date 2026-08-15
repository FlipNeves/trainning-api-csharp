using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context
{
    public class SessionDbContext : DbContext
    {
        public SessionDbContext(DbContextOptions<SessionDbContext> options) : base(options)
        {
        }

        public DbSet<GrupoComissao> GruposComissao { get; set; }
        public DbSet<GrupoCompra> GruposCompra { get; set; }
        public DbSet<GrupoDesconto> GruposDesconto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GrupoComissao>(entity =>
            {
                entity.ToTable("GrupoComissao");
                entity.HasKey(e => new { e.Codigo, e.CdEmpresa });

                entity.Property(x => x.Codigo).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<GrupoCompra>(entity =>
            {
                entity.ToTable("GrupoCompra");
                entity.HasKey(e => new { e.Codigo, e.CdEmpresa });

                entity.Property(x => x.Codigo).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<GrupoDesconto>(entity =>
            {
                entity.ToTable("GrupoDesconto");
                entity.HasKey(e => new { e.Codigo, e.CdEmpresa });

                entity.Property(x => x.Codigo).ValueGeneratedOnAdd();
            });
        }
    }
}
