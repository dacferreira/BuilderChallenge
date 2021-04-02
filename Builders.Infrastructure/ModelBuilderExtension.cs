using Builders.Infrastructure.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace Builders.Infrastructure
{
    public static class ModelBuilderExtension
    {
        public static void MappearEntidades(this ModelBuilder builder)
        {
            var generic = typeof(EntidadeBaseMap<>);

            var todasClasses = Assembly.GetAssembly(generic)
                .GetTypes().
                Where(x => x.IsClass && !x.IsAbstract && IsDerivedOfGenericType(x, generic));

            foreach (var tipos in todasClasses)
            {
                builder.ApplyConfiguration((dynamic)Activator.CreateInstance(tipos));
            }
        }

        public static void AplicarPadraoVarchar(this ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var entity in entityType.GetProperties())
                {
                    if (entity.ClrType == typeof(string) || entity.DeclaringEntityType.ClrType == typeof(string))
                        entity.IsUnicode(false);
                }
            }
        }

        public static void AplicarPadraoDateTime(this ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var entity in entityType.GetProperties())
                {
                    if (entity.ClrType == typeof(DateTime) || entity.DeclaringEntityType.ClrType == typeof(DateTime) || entity.ClrType == typeof(DateTime?) || entity.DeclaringEntityType.ClrType == typeof(DateTime?))
                    {
                        entity.Relational().ColumnType = "datetime";
                    }
                }
            }
        }

        private static bool IsDerivedOfGenericType(Type type, Type genericType)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == genericType)
                return true;
            if (type.BaseType != null)
            {
                return IsDerivedOfGenericType(type.BaseType, genericType);
            }
            return false;
        }
    }
}
