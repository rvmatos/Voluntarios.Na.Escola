using VoluntariosNaEscola.Domain.Entities;
using VoluntariosNaEscola.Domain.Interfaces.Application;
using VoluntariosNaEscola.Domain.Interfaces.Service;

namespace VoluntariosNaEscola.Application
{
    public class VoluntarioApplication : ApplicationBase<Voluntario>, IVoluntarioApplication
    {
        private readonly IVoluntarioService _service;
        public VoluntarioApplication(IVoluntarioService service) : base(service)
        {
            _service = service;
        }
    }
}

