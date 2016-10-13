using System.Collections.Generic;

namespace VoluntariosNaEscola.Domain.Entities
{
    public class Diretor : Usuario
    {
        public Diretor()
        {
            Aprovadores = new HashSet<ConviteAprocao>();
        }
      
        public ICollection<ConviteAprocao> Aprovadores { get; set; }

        public bool Aprovado { get; set; }
    }
}
