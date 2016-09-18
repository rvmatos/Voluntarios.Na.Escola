using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoluntariosNaEscola.Domain
{
    public class Projeto : EntidadeBase
    {
        public Usuario Criador { get; set; }
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public Escola Escola { get; set; }

        public DateTime DtInicio { get; set; }

        public DateTime? DtTerminino { get; set; }

        public ICollection<Supervisor> Supervisores { get; set; }

        public ICollection<Voluntario> Voluntarios { get; set; }

        public ICollection<Acao> Acoes{get; set;}
    }
}
