using VoluntariosNaEscola.Domain.Entities;
using VoluntariosNaEscola.Domain.Interfaces.Repository;
using VoluntariosNaEscola.Domain.Interfaces.Service;
using VoluntariosNaEscola.Domain.Services.Common;

namespace VoluntariosNaEscola.Domain.Services
{
    public class HabilidadeService : ServiceBase<Habilidade>, IHabilidadeService
    {
        private readonly IHabilidadeRepository _repo;
        public HabilidadeService(IHabilidadeRepository repo) : base(repo)
        {
            _repo = repo;
        }
    }
}
