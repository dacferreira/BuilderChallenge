using Builders.Dominio.Entidades;
using Builders.Dominio.Servico;
using Builders.TestUnitario.Context;

namespace Builders.TestUnitario.Builder
{
    public class ArvoreBuilder : IBuilder<ArvoreBusca>
    {
        private readonly BuildersContext _context;

        public ArvoreBuilder(BuildersContext context)
        {
            _context = context;
        }

        public static implicit operator ArvoreService(ArvoreBuilder builder) =>
            builder.Build();

        public ArvoreService Build() =>
            new ArvoreService(_context._unitOfWork.Object,
                                _context._noArvoreRepositorio.Object);

        public ArvoreBusca Criar()
        {
            return new ArvoreBusca
            {
                Id = default(int),
                Raiz = new NoArvore
                {
                    Numero = 4
                }
            };
        }
    }
}
