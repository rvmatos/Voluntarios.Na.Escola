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
        public ICollection<Escola> Escolas { get; set; }     
        public ICollection<Evento>  Eventos { get; set; }

    }
}