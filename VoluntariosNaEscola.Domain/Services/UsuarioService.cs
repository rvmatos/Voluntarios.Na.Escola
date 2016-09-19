using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoluntariosNaEscola.Domain.Entities;
using VoluntariosNaEscola.Domain.Interfaces.Repository;
using VoluntariosNaEscola.Domain.Interfaces.Service;
using VoluntariosNaEscola.Domain.Services.Common;

namespace VoluntariosNaEscola.Domain.Services
{
    public class UsuarioService : ServiceBase<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository _repo;
        public UsuarioService(IUsuarioRepository repo) : base(repo)
        {
            _repo = repo;
        }
    }
}
