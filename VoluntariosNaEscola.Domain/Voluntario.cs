using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoluntariosNaEscola.Domain
{
    public class Voluntario : Usuario
    {
        public ICollection<Escola> Escolas { get; set; }

        public ICollection<Projeto> Projetos { get; set; }
    }
}
