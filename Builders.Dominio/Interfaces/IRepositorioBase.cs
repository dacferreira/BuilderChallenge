using Builders.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Builders.Dominio.Interfaces
{
    public interface IRepositorioBase<T> : IRepositorio where T : EntidadeBase
    {
        void Atualizar(T objeto);
        void Inserir(T objeto);
        void Excluir(T objeto);
        List<T> Obter(Expression<Func<T, bool>> condicao);
        T ObterSomente(Expression<Func<T, bool>> condicao);
        T ObterPorId(int id);
        List<T> ObterTodos();
    }
}
