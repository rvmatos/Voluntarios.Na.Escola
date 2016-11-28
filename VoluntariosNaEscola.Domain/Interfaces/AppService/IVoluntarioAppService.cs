using System;
using System.Net.Http;
using VoluntariosNaEscola.Domain.Entities;
using VoluntariosNaEscola.Domain.Interfaces.AppService.Common;
using VoluntariosNaEscola.Domain.Validations;

namespace VoluntariosNaEscola.Domain.Interfaces.AppService
{
    public interface IVoluntarioAppService : IDisposable, IAppService<Voluntario>
    {
        HttpResponseMessage VincularEscola(int idEscola, int idVoluntario);
    }
}
