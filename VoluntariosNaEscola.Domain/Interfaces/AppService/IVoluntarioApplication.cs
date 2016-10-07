using System;
using VoluntariosNaEscola.Domain.Entities;
using VoluntariosNaEscola.Domain.Interfaces.AppService.Common;

namespace VoluntariosNaEscola.Domain.Interfaces.AppService
{
    public interface IVoluntarioAppService : IDisposable, IAppService<Voluntario>
    {
    }
}
