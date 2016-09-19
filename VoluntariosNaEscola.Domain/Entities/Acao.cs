using System.Collections.Generic;

namespace VoluntariosNaEscola.Domain.Entities
{
    public class Acao : EntidadeBase
    {
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string Objetivo { get; set; }
        
        public Evento Evento { get; set; }

    }
}