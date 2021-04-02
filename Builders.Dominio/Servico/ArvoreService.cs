using Builders.Dominio.Entidades;
using Builders.Dominio.Extensions;
using Builders.Dominio.Interfaces;
using System;

namespace Builders.Dominio.Servico
{
    public class ArvoreService : ServicoBase<ArvoreBusca, IArvoreRepositorio>, IArvoreService
    {
        private readonly INoArvoreRepositorio _noArvoreRepositorio;
        public ArvoreService(IUnitOfWork unitOfWork, INoArvoreRepositorio noArvoreRepositorio) : base(unitOfWork)
        {
            this._noArvoreRepositorio = noArvoreRepositorio ?? throw new ArgumentNullException(nameof(noArvoreRepositorio));
        }
        public void Inserir(int numero, ArvoreBusca arvoreBusca)
        {
            if (arvoreBusca == null) arvoreBusca = new ArvoreBusca();

            var raiz = arvoreBusca.Raiz;

            Inserir(numero, arvoreBusca.Id, ref raiz);

            if (arvoreBusca.Id == default(int))
            {
                arvoreBusca.SetRaiz(raiz);
                this._repositorio.Inserir(arvoreBusca);
            }
        }
        private void Inserir(int item, int idArvoreBusca, ref NoArvore noArvore)
        {
            if (noArvore == null || noArvore.Id == default(int))
            {
                noArvore = new NoArvore();
                noArvore.IniciarEntidade(item);
                noArvore.IdArvoreBusca = idArvoreBusca;
            }
            else
            {
                NoArvore novoItem = new NoArvore();
                bool ehNoEsquerdo = false;
                bool ehNoDireito = false;
                if (item.CompareTo(noArvore.Numero) < 0)
                {
                    ehNoEsquerdo = true;
                    Inserir(item, noArvore.Id, ref novoItem);
                }
                else if (item.CompareTo(noArvore.Numero) > 0)
                {
                    ehNoDireito = true;
                    Inserir(item, noArvore.Id, ref novoItem);
                }

                if (ehNoEsquerdo)
                {
                    novoItem.Altura = Math.Max(novoItem.ObterAltura(), noArvore.NoDireito.ObterAltura()) + 1;

                    InserirNoArvore(noArvore, novoItem, false);
                }
                else if (ehNoDireito)
                {
                    novoItem.Altura = Math.Max(noArvore.NoEsquerdo.ObterAltura(), novoItem.ObterAltura()) + 1;
                    InserirNoArvore(noArvore, novoItem);
                }
            }
        }

        private void InserirNoArvore(NoArvore noArvore, NoArvore novoItem, bool noDireito = true)
        {
            var _arv = new ArvoreBusca { Raiz = novoItem };

            this._repositorio.Inserir(_arv);

            var _raizAlterado = this._noArvoreRepositorio.ObterPorId(noArvore.Id);
            if (_raizAlterado != null)
            {
                if(noDireito)
                _raizAlterado.AdicionarDireito(novoItem);
                else
                    _raizAlterado.AdicionarEsquerdo(novoItem);
                this._noArvoreRepositorio.Atualizar(novoItem);
            }
        }

        public ArvoreBusca ObterPrimeiroNo()
        {
            return this._repositorio
                       .ObterSomente(a => a.Raiz.Altura == default(int));
        }
    }
}
