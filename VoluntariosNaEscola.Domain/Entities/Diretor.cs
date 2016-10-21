using System.Collections.Generic;

namespace VoluntariosNaEscola.Domain.Entities
{
    public class Diretor : Usuario
    {
        public Diretor()
        {
            Aprovadores = new HashSet<ConviteAprovacao>();
        }
      
        public ICollection<ConviteAprovacao> Aprovadores { get; set; }

        public bool Aprovado { get; set; }
    }
}
