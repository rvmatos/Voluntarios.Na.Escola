using System.Collections.Generic;

namespace VoluntariosNaEscola.Domain
{
    public class Supervisor : Usuario
    {
        public ICollection<Escola> Escolas { get; set; }       

    }
}