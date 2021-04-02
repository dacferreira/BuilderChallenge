using Builders.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Builders.Infrastructure
{
    public class BuildersDbContext : DbContext
    {
        public BuildersDbContext(DbContextOptions<BuildersDbContext> options)
         : base(options)
        {

        }

        public DbSet<ArvoreBusca> ArvoreBusca { get; set; }
        public DbSet<NoArvore> NoArvore { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.MappearEntidades();
            modelBuilder.AplicarPadraoDateTime();
            modelBuilder.AplicarPadraoVarchar();
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCriacao") != null))
            {
                if (entry.State == EntityState.Added)
                    entry.Property("DataCriacao").CurrentValue = DateTime.Now;

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCriacao").IsModified = false;
                    entry.Property("DataAlteracao").CurrentValue = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }
    }
}
