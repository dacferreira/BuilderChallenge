using Builders.Dominio.Entidades;
using Builders.Dominio.Interfaces;

namespace Builders.Infrastructure.Repositorio
{
    public class NoArvoreRepositorio : RepositorioBase<NoArvore>, INoArvoreRepositorio
    {
        private readonly BuildersDbContext context;

        public NoArvoreRepositorio(BuildersDbContext context) : base(context)
        {
            this.context = context;
        }

    }
}
