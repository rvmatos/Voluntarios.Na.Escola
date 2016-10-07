using VoluntariosNaEscola.Domain.Entities;
using VoluntariosNaEscola.Domain.Interfaces.Application;
using VoluntariosNaEscola.Domain.Interfaces.Service;

namespace VoluntariosNaEscola.Application
{
    public class UsuarioApplication : ApplicationBase<Usuario>, IUsuarioApplication
    {
        private readonly IUsuarioService _service;
        public UsuarioApplication(IUsuarioService service) : base(service)
        {
            _service = service;
        }
    }
}
