namespace Builders.Dominio.Entidades
{
    public class ArvoreBusca : EntidadeBase
    {
        protected NoArvore _raiz;
        public virtual NoArvore Raiz
        {
            get
            {
                return _raiz;
            }
            set
            {
                _raiz = value;
            }
        }

        public void SetRaiz(NoArvore raiz)
        {
            this.Raiz = raiz;
        }
    }
}
