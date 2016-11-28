using System;
using VoluntariosNaEscola.Domain.Entities;
using VoluntariosNaEscola.Domain.Interfaces.Repository;
using VoluntariosNaEscola.Domain.Interfaces.Service;
using VoluntariosNaEscola.Domain.Services.Common;
using VoluntariosNaEscola.Domain.Validations;

namespace VoluntariosNaEscola.Domain.Services
{
    public class VoluntarioService : ServiceBase<Voluntario>, IVoluntarioService
    {
        private readonly IVoluntarioRepository _repo;
        public VoluntarioService(IVoluntarioRepository repo) : base(repo)
        {
            _repo = repo;
        }

        public ValidationResult VincularEscola(int idEscola, int idVoluntario)
        {
           var result = new ValidationResult();
            try
            {
                _repo.VincularEscola(idEscola, idVoluntario);
            }
            catch (Exception ex)
            {
                result.Add(ex.StackTrace);
            }
            return result;
        }
    }
}
