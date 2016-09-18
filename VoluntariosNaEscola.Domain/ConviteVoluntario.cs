using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoluntariosNaEscola.Domain
{
    public class ConviteVoluntario : EntidadeBase
    {
        public Escola Escola { get; set; }

        public Voluntario Voluntario { get; set; }

        public DateTime? DtEnvio { get; set; }

        public DateTime? DtAceite { get; set; }

    }
}
