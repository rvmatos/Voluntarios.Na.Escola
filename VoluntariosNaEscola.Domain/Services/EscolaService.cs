using VoluntariosNaEscola.Domain.Entities;
using VoluntariosNaEscola.Domain.Interfaces.Repository;
using VoluntariosNaEscola.Domain.Interfaces.Service;
using VoluntariosNaEscola.Domain.Services.Common;

namespace VoluntariosNaEscola.Domain.Services
{
    public class EscolaService : ServiceBase<Escola>, IEscolaService
    {
        private readonly IEscolaRepository _repo;
        public EscolaService(IEscolaRepository repo) : base(repo)
        {
            _repo = repo;
        }
    }
}
