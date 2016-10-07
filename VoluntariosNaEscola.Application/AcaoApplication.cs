using VoluntariosNaEscola.Domain.Entities;
using VoluntariosNaEscola.Domain.Interfaces.Application;
using VoluntariosNaEscola.Domain.Interfaces.Service;

namespace VoluntariosNaEscola.Application
{
    public class AcaoApplication : ApplicationBase<Acao>, IAcaoApplication
    {
        private readonly IAcaoService _service;
        public AcaoApplication(IAcaoService service) : base(service)
        {
            _service = service;
        }
    }
}
