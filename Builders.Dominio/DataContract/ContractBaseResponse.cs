using System.Collections.Generic;

namespace Builders.Dominio.DataContract
{
    public abstract class ContractBaseResponse<T> where T : class
    {
        public T Data { get; set; }
        public string Mensagem { get; set; }

        public IList<string> Validacoes { get; set; }

        public ContractBaseResponse()
        {
            this.Validacoes = new List<string>();
        }
    }
}
