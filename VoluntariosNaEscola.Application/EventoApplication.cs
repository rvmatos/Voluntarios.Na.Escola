using VoluntariosNaEscola.Domain.Entities;
using VoluntariosNaEscola.Domain.Interfaces.Application;
using VoluntariosNaEscola.Domain.Interfaces.Service;

namespace VoluntariosNaEscola.Application
{
    public class EventoApplication : ApplicationBase<Evento>, IEventoApplication
    {
        private readonly IEventoService _service;
        public EventoApplication(IEventoService service) : base(service)
        {
            _service = service;
        }
    }
}
