using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoluntariosNaEscola.Domain.Entities
{
    public class ConviteAprocao : EntidadeBase
    {
        public string Email { get; set; }

        public DateTime? DtEnvio { get; set; }

        public Guid ChaveConfirmacao { get; set; }
        
        public bool DiretorAprovado { get; set; }
        
        public bool ConviteAceito { get; set; } 
    }
}
