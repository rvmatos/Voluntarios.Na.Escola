using System;

namespace VoluntariosNaEscola.Domain.Entities
{
    public class ConviteVoluntario : EntidadeBase
    {
        public virtual Escola Escola { get; set; }

        public int IdEscola { get; set; }

        public virtual Voluntario Voluntario { get; set; }

        public int IdVoluntario { get; set; }

        public DateTime? DtEnvio { get; set; }

        public DateTime? DtAceite { get; set; }

    }
}
