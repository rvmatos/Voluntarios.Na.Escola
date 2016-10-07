using VoluntariosNaEscola.Domain.Entities;
using VoluntariosNaEscola.Domain.Interfaces.Application;
using VoluntariosNaEscola.Domain.Interfaces.Service;

namespace VoluntariosNaEscola.Application
{
    public class EscolaApplication : ApplicationBase<Escola>, IEscolaApplication
    {
        private readonly IEscolaService _service;
        public EscolaApplication(IEscolaService service) : base(service)
        {
            _service = service;
        }
    }
}
