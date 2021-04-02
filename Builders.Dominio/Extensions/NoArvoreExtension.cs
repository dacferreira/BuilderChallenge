using Builders.Dominio.Entidades;
using System;

namespace Builders.Dominio.Extensions
{
    public static class NoArvoreExtension
    {
        public static string ObterEmOrdem(this NoArvore NoArvore)
        {
            if (NoArvore == null)
                return "";
            else
            {
                return $"{ObterEmOrdem(NoArvore.NoEsquerdo)} {NoArvore.Numero} {ObterEmOrdem(NoArvore.NoDireito)}";
            }
        }

        public static int ObterAltura(this NoArvore no)
        {
            if (no != null)
                return no.Altura;
            else
                return -1;
        }
    }
}
