using Builders.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Builders.Dominio.Interfaces
{
    public interface IServicoBase<T> : IServico where T : EntidadeBase
    {
        void Atualizar(T objeto);
        void Inserir(T objeto);
        void Excluir(T objeto);
        T ObterPorId(int id);
        List<T> ObterTodos();
        List<T> Obter(Expression<Func<T, bool>> condicao);
    }
}
