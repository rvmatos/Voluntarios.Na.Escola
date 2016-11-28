using System;
using VoluntariosNaEscola.Domain.Entities;
using VoluntariosNaEscola.Domain.Interfaces.Application.Common;
using VoluntariosNaEscola.Domain.Validations;

namespace VoluntariosNaEscola.Domain.Interfaces.Application
{
    public interface IVoluntarioApplication : IDisposable, IApplication<Voluntario>
    {
        bool IsVoluntario(int id);
        ValidationResult VincularEscola(int idEscola, int idVoluntario);
    }
}
