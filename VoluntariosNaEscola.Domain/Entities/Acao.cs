namespace VoluntariosNaEscola.Domain.Entities
{
    public class Acao : EntidadeBase
    {
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string Objetivo { get; set; }
        
        public virtual Evento Evento { get; set; }

        public int IdEvento { get; set; }
    }
}