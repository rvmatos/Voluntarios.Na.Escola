using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoluntariosNaEscola.Domain.Entities
{
    public class EntidadeBase
    {
        public int Id { get; set; }
        public bool Ativo { get; set; }
        public bool Excluido { get; set; }

        public DateTime DtCriacao { get; set; }

        public DateTime DtExclusao { get; set; }

    }
}
