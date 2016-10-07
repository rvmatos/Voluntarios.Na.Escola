using VoluntariosNaEscola.Domain.Entities;
using VoluntariosNaEscola.Domain.Interfaces.Application;
using VoluntariosNaEscola.Domain.Interfaces.Service;

namespace VoluntariosNaEscola.Application
{
    public class EnderecoApplication : ApplicationBase<Endereco>, IEnderecoApplication
    {
        private readonly IEnderecoService _service;
        public EnderecoApplication(IEnderecoService service) : base(service)
        {
            _service = service;
        }
    }
}
