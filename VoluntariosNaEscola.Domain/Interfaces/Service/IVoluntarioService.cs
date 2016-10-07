using System;
using VoluntariosNaEscola.Domain.Entities;
using VoluntariosNaEscola.Domain.Interfaces.Service.Common;

namespace VoluntariosNaEscola.Domain.Interfaces.Service
{
    public interface IVoluntarioService : IDisposable, IService<Voluntario>
    {
    }
}
