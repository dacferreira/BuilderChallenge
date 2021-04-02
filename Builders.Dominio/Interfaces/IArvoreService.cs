using Builders.Dominio.Entidades;

namespace Builders.Dominio.Interfaces
{
    public interface IArvoreService : IServico
    {
        void Inserir(int numero, ArvoreBusca arvore);
        ArvoreBusca ObterPrimeiroNo();
    }
}
