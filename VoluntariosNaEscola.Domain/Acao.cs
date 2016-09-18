using System.Collections.Generic;

namespace VoluntariosNaEscola.Domain
{
    public class Acao : EntidadeBase
    {
        public string Nome { get; set; }

        public string Descricao { get; set; }
        
        public ICollection<Projeto> Projetos { get; set; }

    }
}