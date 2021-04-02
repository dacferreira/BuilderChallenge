using Builders.Dominio.Entidades;
using Builders.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Builders.Infrastructure.Repositorio
{
    public class ArvoreRepositorio : RepositorioBase<ArvoreBusca>, IArvoreRepositorio
    {
        private readonly BuildersDbContext context;

        public ArvoreRepositorio(BuildersDbContext context) : base(context)
        {
            this.context = context;
        }

        public override ArvoreBusca ObterSomente(Expression<Func<ArvoreBusca, bool>> condicao)
        {
            return context.ArvoreBusca
                          .Include(a => a.Raiz)
                          .ThenInclude(a => a.ArvoreBusca)
                          .Include(a => a.Raiz)
                          .ThenInclude(a => a.NoEsquerdo)
                          .ThenInclude(a => a.ArvoreBusca)
                          .Include(a => a.Raiz)
                          .ThenInclude(a => a.NoDireito)
                          .ThenInclude(a => a.ArvoreBusca)
                          .Where(condicao).FirstOrDefault();
        }
    }
}
