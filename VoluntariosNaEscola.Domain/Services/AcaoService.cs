using VoluntariosNaEscola.Domain.Entities;
using VoluntariosNaEscola.Domain.Interfaces.Repository;
using VoluntariosNaEscola.Domain.Interfaces.Service;
using VoluntariosNaEscola.Domain.Services.Common;

namespace VoluntariosNaEscola.Domain.Services
{
    public class AcaoService : ServiceBase<Acao>, IAcaoService
    {
        private readonly IAcaoRepository _repo;
        public AcaoService(IAcaoRepository repo) : base(repo)
        {
            _repo = repo;
        }
    }
}
