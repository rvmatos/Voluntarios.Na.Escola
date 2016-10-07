using System.Collections.Generic;

namespace VoluntariosNaEscola.Domain.Entities
{
    public class Habilidade : EntidadeBase
    {
        public Habilidade()
        {
            Voluntarios = new HashSet<Voluntario>();
            Eventos = new HashSet<Evento>();
        }
        public string Nome { get; set; }

        public ICollection<Voluntario> Voluntarios { get; set; }

        public ICollection<Evento> Eventos { get; set; }

    }
}
