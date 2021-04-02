using Builders.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Builders.Infrastructure.Migrations
{
    public abstract class EntidadeBaseMap<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : EntidadeBase
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .HasColumnName($"Id{typeof(TEntity).Name}")
                   .ValueGeneratedOnAdd();

            builder.Property(x => x.DataCriacao)
                   .HasColumnType("smalldatetime")
                   .IsRequired();

            builder.Property(x => x.DataAlteracao)
                   .HasColumnType("smalldatetime");

            ConfigureMainBuilder(builder);
        }

        public abstract void ConfigureMainBuilder(EntityTypeBuilder<TEntity> builder);
    }

    public class ArvoreBuscaMap : EntidadeBaseMap<ArvoreBusca>
    {
        public override void ConfigureMainBuilder(EntityTypeBuilder<ArvoreBusca> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(p => p.Raiz)
                   .WithOne(f => f.ArvoreBusca)
                   .HasForeignKey<NoArvore>(x => x.IdArvoreBusca)
                   .IsRequired();
        }
    }

    public class NoArvoreMap : EntidadeBaseMap<NoArvore>
    {
        public override void ConfigureMainBuilder(EntityTypeBuilder<NoArvore> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Altura)
                   .IsRequired();

            builder.HasOne(x => x.NoEsquerdo)
                .WithOne()
                .HasForeignKey<NoArvore>(x => x.IdNoEsquerdo);


            builder.HasOne(x => x.NoDireito)
                .WithOne()
                .HasForeignKey<NoArvore>(x => x.IdNoDireito);
        }
    }
}
