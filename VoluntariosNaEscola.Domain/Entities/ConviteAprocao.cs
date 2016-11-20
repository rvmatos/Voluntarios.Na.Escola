using System;

namespace VoluntariosNaEscola.Domain.Entities
{
    public class ConviteAprovacao : EntidadeBase
    {
        public virtual Diretor Diretor { get; set; }

        public int IdDiretor { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public DateTime? DtEnvio { get; set; }

        public DateTime? DtAceite { get; set; }

        public Guid ChaveConfirmacao { get; set; }
        
        public bool? DiretorAprovado { get; set; }
        
        public bool ConviteAceito { get; set; } 
    }
}
