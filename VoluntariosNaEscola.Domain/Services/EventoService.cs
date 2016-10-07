using VoluntariosNaEscola.Domain.Entities;
using VoluntariosNaEscola.Domain.Interfaces.Repository;
using VoluntariosNaEscola.Domain.Interfaces.Service;
using VoluntariosNaEscola.Domain.Services.Common;

namespace VoluntariosNaEscola.Domain.Services
{
    public class EventoService : ServiceBase<Evento>, IEventoService
    {
        private readonly IEventoRepository _repo;
        public EventoService(IEventoRepository repo) : base(repo)
        {
            _repo = repo;
        }
    }
}
