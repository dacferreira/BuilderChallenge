using System;

namespace Builders.Dominio.Entidades
{
    public class EntidadeBase
    {
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}
