using System;
using System.Net.Http;
using VoluntariosNaEscola.Domain.Entities;
using VoluntariosNaEscola.Domain.Interfaces.AppService.Common;

namespace VoluntariosNaEscola.Domain.Interfaces.AppService
{
    public interface IUsuarioAppService : IDisposable, IAppService<Usuario>
    {

        HttpResponseMessage Autenticar(string usuario, string senha);

    }
}
