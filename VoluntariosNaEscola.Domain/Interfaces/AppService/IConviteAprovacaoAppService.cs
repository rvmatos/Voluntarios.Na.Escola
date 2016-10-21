using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VoluntariosNaEscola.Domain.Entities;
using VoluntariosNaEscola.Domain.Interfaces.AppService.Common;
using VoluntariosNaEscola.Domain.Validations;

namespace VoluntariosNaEscola.Domain.Interfaces.AppService
{
    public interface IConviteAprovacaoAppService : IAppService<ConviteAprovacao>
    {
        HttpResponseMessage ReenviarConvite(int id);
        HttpResponseMessage GetConvitesBy(int idDiretor);
    }
}
