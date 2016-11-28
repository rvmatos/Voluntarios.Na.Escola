using System;
using System.Collections.Generic;

namespace VoluntariosNaEscola.Domain.Entities
{
    public class Evento : EntidadeBase
    {
        public Evento()
        {
            HabilidadesRequeridas = new HashSet<Habilidade>();
            Supervisores = new HashSet<Supervisor>();
            Voluntarios = new HashSet<Voluntario>();
            Acoes = new HashSet<Acao>();

        }
        public virtual Usuario Criador { get; set; }

        public int IdUsuarioCriador { get; set; }
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public virtual Escola Escola { get; set; }


        public int IdEscola { get; set; }

        public DateTime DtInicio { get; set; }

        public DateTime? DtTermino { get; set; }

        public int? NroMinimoVoluntarios { get; set; }

        public int? NroMaximoVoluntarios { get; set; }

        public ICollection<Habilidade> HabilidadesRequeridas { get; set; }

        public virtual ICollection<Supervisor> Supervisores { get; set; }

        public virtual ICollection<Voluntario> Voluntarios { get; set; }

        public ICollection<Acao> Acoes{get; set;}
    }
}
