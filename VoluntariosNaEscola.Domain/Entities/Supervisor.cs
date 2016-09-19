using System.Collections.Generic;

namespace VoluntariosNaEscola.Domain.Entities
{
    public class Supervisor : Usuario
    {
        public ICollection<Escola> Escolas { get; set; }       

    }
}