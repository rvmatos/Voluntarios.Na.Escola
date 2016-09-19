using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoluntariosNaEscola.Domain.Entities
{
    public class Voluntario : Usuario
    {
        public ICollection<Escola> Escolas { get; set; }

        public ICollection<Evento> Eventos { get; set; }

        public ICollection<Habilidade> Habilidades { get; set; }
    }
}
