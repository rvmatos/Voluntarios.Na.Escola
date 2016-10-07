using VoluntariosNaEscola.Domain.Entities;
using VoluntariosNaEscola.Domain.Interfaces.Repository;
using VoluntariosNaEscola.Domain.Interfaces.Service;
using VoluntariosNaEscola.Domain.Services.Common;

namespace VoluntariosNaEscola.Domain.Services
{
    public class VoluntarioService : ServiceBase<Voluntario>, IVoluntarioService
    {
        private readonly IVoluntarioRepository _repo;
        public VoluntarioService(IVoluntarioRepository repo) : base(repo)
        {
            _repo = repo;
        }
    }
}
