using System.Collections.Generic;

namespace VoluntariosNaEscola.Domain.Entities
{
    public class Voluntario : Usuario
    {
        public Voluntario()
        {
            Escolas = new HashSet<Escola>();
            Eventos = new HashSet<Evento>();
            Habilidades = new HashSet<Habilidade>();
        }
        public virtual Endereco Endereco { get; set; }        
        public int IdEndereco { get; set; } 
        public ICollection<Escola> Escolas { get; set; }

        public ICollection<Evento> Eventos { get; set; }

        public ICollection<Habilidade> Habilidades { get; set; }
    }
}
