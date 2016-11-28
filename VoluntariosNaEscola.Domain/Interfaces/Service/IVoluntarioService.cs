using System;
using VoluntariosNaEscola.Domain.Entities;
using VoluntariosNaEscola.Domain.Interfaces.Service.Common;
using VoluntariosNaEscola.Domain.Validations;

namespace VoluntariosNaEscola.Domain.Interfaces.Service
{
    public interface IVoluntarioService : IDisposable, IService<Voluntario>
    {
        ValidationResult VincularEscola(int idEscola, int idVoluntario);
    }
}
