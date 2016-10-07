using VoluntariosNaEscola.Domain.Entities;
using VoluntariosNaEscola.Domain.Interfaces.Application;
using VoluntariosNaEscola.Domain.Interfaces.Service;

namespace VoluntariosNaEscola.Application
{
    public class HabilidadeApplication : ApplicationBase<Habilidade>, IHabilidadeApplication
    {
        private readonly IHabilidadeService _service;
        public HabilidadeApplication(IHabilidadeService service) : base(service)
        {
            _service = service;
        }
    }
}
