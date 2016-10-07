using VoluntariosNaEscola.Domain.Entities;
using VoluntariosNaEscola.Domain.Interfaces.Repository;
using VoluntariosNaEscola.Domain.Interfaces.Service;
using VoluntariosNaEscola.Domain.Services.Common;

namespace VoluntariosNaEscola.Domain.Services
{
    public class SupervisorService : ServiceBase<Supervisor>, ISupervisorService
    {
        private readonly ISupervisorRepository _repo;
        public SupervisorService(ISupervisorRepository repo) : base(repo)
        {
            _repo = repo;
        }
    }
}
