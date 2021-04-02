using Builders.Dominio.Entidades;
using Builders.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Builders.Dominio.Servico
{
    public abstract class ServicoBase<T, TRepositorio> : IServicoBase<T>
        where T : EntidadeBase
        where TRepositorio : IRepositorioBase<T>
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly TRepositorio _repositorio;

        protected ServicoBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repositorio = _unitOfWork.GetRepositorio<TRepositorio>();
        }

        public virtual List<T> ObterTodos()
        {
            return _repositorio.ObterTodos();
        }

        public virtual T ObterPorId(int id)
        {
            return _repositorio.ObterPorId(id);
        }

        public virtual void Inserir(T objeto)
        {
            _repositorio.Inserir(objeto);
        }

        public virtual void Atualizar(T objeto)
        {
            _repositorio.Atualizar(objeto);
        }

        public virtual void Excluir(T objeto)
        {
            _repositorio.Excluir(objeto);
        }

        public List<T> Obter(Expression<Func<T, bool>> condicao)
        {
            return _repositorio.Obter(condicao);
        }
    }
}
