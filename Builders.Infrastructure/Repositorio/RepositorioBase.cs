using Builders.Dominio.Entidades;
using Builders.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Builders.Infrastructure.Repositorio
{
    public abstract class RepositorioBase<T> : IRepositorioBase<T> where T : EntidadeBase
    {
        private readonly BuildersDbContext _context;

        protected RepositorioBase(BuildersDbContext context)
        {
            _context = context;
        }

        public virtual List<T> ObterTodos()
        {
            return _context.Set<T>()
                .OrderByDescending(x => x.DataCriacao)
                .ToList();
        }

        public virtual T ObterPorId(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public virtual void Atualizar(T objeto)
        {
            _context.Set<T>().Update(objeto);
            _context.SaveChanges();
        }

        public virtual void Excluir(T objeto)
        {
            _context.Set<T>().Remove(objeto);
            _context.SaveChanges();
        }

        public virtual List<T> Obter(Expression<System.Func<T, bool>> condicao)
        {
            return _context.Set<T>()
                .Where(condicao)
                .ToList();
        }

        public virtual T ObterSomente(Expression<Func<T, bool>> condicao)
        {
            return _context.Set<T>().Where(condicao).FirstOrDefault();
        }

        public virtual void Inserir(T objeto)
        {
            _context.Set<T>().Add(objeto);
            _context.SaveChanges();
        }
    }
}
