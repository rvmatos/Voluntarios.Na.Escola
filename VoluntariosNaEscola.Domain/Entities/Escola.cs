using System.Collections.Generic;

namespace VoluntariosNaEscola.Domain.Entities
{
    public class Escola : EntidadeBase
    {
        public Escola()
        {
            Supervisores = new HashSet<Supervisor>();
            Voluntarios = new HashSet<Voluntario>();
        }
        public string Nome { get; set; }
        public virtual Endereco Endereco { get; set; }

        public int IdEndereco { get; set; }

        public virtual Diretor Diretor { get; set; }

        public int IdDiretor { get; set; }

        public virtual ICollection<Supervisor> Supervisores { get; set; }

        public virtual ICollection<Voluntario> Voluntarios { get; set; }


        public bool AprovacaoAutomaticaVoluntarios { get; set; }

    }
}
