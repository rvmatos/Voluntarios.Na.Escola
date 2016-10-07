using System;
using VoluntariosNaEscola.Domain.Entities;
using VoluntariosNaEscola.Domain.Interfaces.Service.Common;

namespace VoluntariosNaEscola.Domain.Interfaces.Service
{
    public interface IEventoService : IDisposable, IService<Evento>
    {
    }
}
