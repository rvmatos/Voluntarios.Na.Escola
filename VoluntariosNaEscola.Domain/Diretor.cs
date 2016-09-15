using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoluntariosNaEscola.Domain
{
    public class Diretor : Usuario
    {
        public Escola Escola { set; get; }

        public Endereco Endereco { get; set; }

        public List<Aprovador> Colaboradores { get; set; }
    }
}
