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

        public ICollection<ConviteAprocao> Aprovadores { get; set; }

        public bool Aprovado { get; set; }
    }
}
