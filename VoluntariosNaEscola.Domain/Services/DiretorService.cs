using VoluntariosNaEscola.Domain.Entities;
using VoluntariosNaEscola.Domain.Interfaces.Repository;
using VoluntariosNaEscola.Domain.Interfaces.Service;
using VoluntariosNaEscola.Domain.Services.Common;

namespace VoluntariosNaEscola.Domain.Services
{
    public class DiretorService : ServiceBase<Diretor>, IDiretorService
    {
        private readonly IDiretorRepository _repo;
        public DiretorService(IDiretorRepository repo) : base(repo)
        {
            _repo = repo;
        }
    }
}
