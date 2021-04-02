using System;

namespace Builders.Dominio.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        TRepositorio GetRepositorio<TRepositorio>() where TRepositorio : IRepositorio;
        void Commit();
    }
}
