using VoluntariosNaEscola.Domain.Entities;
using VoluntariosNaEscola.Domain.Interfaces.Application;
using VoluntariosNaEscola.Domain.Interfaces.Service;

namespace VoluntariosNaEscola.Application
{
    public class SupervisorApplication : ApplicationBase<Supervisor>, ISupervisorApplication
    {
        private readonly ISupervisorService _service;
        public SupervisorApplication(ISupervisorService service) : base(service)
        {
            _service = service;
        }

        public bool IsSupervisor(int id)
        {
            try
            {
                return _service.Get(id) != null;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

    }
}
