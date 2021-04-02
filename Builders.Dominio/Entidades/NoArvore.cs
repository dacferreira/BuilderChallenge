namespace Builders.Dominio.Entidades
{
    public class NoArvore : EntidadeBase
    {
        public int IdArvoreBusca { get; set; }
        public virtual ArvoreBusca ArvoreBusca { get; set; }
        public int Altura { get; set; }

        public int Numero { get; set; }

        public int? IdNoEsquerdo { get; set; }
        public NoArvore _noEsquerdo;
        public virtual NoArvore NoEsquerdo
        {
            get
            {
                return _noEsquerdo;
            }
            set
            {
                _noEsquerdo = value;
            }
        }

        public int? IdNoDireito { get; set; }
        public NoArvore _noDireito;
        public virtual NoArvore NoDireito
        {
            get
            {
                return _noDireito;
            }
            set
            {
                _noDireito = value;
            }
        }

        public void AdicionarDireito(NoArvore noDireito)
        {
            this.NoDireito = noDireito;
        }
        public void IniciarEntidade(int numero)
        {
            this.Numero = numero;
            this.NoEsquerdo = null;
            this.NoDireito = null;
            this.Altura = default(int);
        }
    }
}
