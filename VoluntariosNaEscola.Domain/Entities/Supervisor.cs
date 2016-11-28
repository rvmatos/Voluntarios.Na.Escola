using System.Collections.Generic;

namespace VoluntariosNaEscola.Domain.Entities
{
    public class Supervisor : Usuario
    {
        public Supervisor()
        {
            Escolas = new HashSet<Escola>();
            Eventos = new HashSet<Evento>();
        }
        public virtual ICollection<Escola> Escolas { get; set; }     
        public virtual ICollection<Evento>  Eventos { get; set; }

    }
}