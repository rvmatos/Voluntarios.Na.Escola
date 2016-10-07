using System;

namespace VoluntariosNaEscola.Domain.Entities
{
    public abstract class EntidadeBase
    {
        public int Id { get; set; }
        public bool Ativo { get; set; }
        public bool Excluido { get; set; }

        public DateTime DtCriacao { get; set; }

        public DateTime DtAtualizacao { get; set; }

    }
}
