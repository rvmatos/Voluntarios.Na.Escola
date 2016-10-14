using VoluntariosNaEscola.Domain.Entities;
using VoluntariosNaEscola.Domain.Interfaces.Application;
using VoluntariosNaEscola.Domain.Interfaces.Service;

namespace VoluntariosNaEscola.Application
{
    public class DiretorApplication : ApplicationBase<Diretor>, IDiretorApplication
    {
        private readonly IDiretorService _service;
        public DiretorApplication(IDiretorService service) : base(service)
        {
            _service = service;
        }


        public bool IsDiretor(int id)
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
