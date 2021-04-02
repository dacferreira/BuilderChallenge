using Builders.Dominio.Interfaces;
using System;

namespace Builders.Infrastructure.Repositorio
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BuildersDbContext _projetoDbContext;
        private readonly IServiceProvider _serviceProvider;

        public UnitOfWork(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _projetoDbContext = GetInstance<BuildersDbContext>();
        }

        public void BeginTransaction()
        {
            _projetoDbContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            if (_projetoDbContext.Database.CurrentTransaction != null)
            {
                _projetoDbContext.Database.CommitTransaction();
            }
        }

        public void Dispose()
        {

            if (_projetoDbContext.Database.CurrentTransaction != null)
            {
                _projetoDbContext.Database.RollbackTransaction();
            }

            _projetoDbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public TRepositorio GetRepositorio<TRepositorio>() where TRepositorio : IRepositorio
        {
            return GetInstance<TRepositorio>();
        }

        private T GetInstance<T>()
        {
            return (T)_serviceProvider.GetService(typeof(T));
        }
    }
}
