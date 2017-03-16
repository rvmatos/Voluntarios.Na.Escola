using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using VoluntariosNaEscola.Domain.Entities;
using VoluntariosNaEscola.Domain.Interfaces.Application;
using VoluntariosNaEscola.Domain.Interfaces.Application.Common;
using VoluntariosNaEscola.Domain.Interfaces.AppService;

namespace VoluntariosNaEscola.AppService.Core.Controller
{
    [Authorize]
    public class ConviteAprovacaoController : BaseController<ConviteAprovacao>, IConviteAprovacaoAppService
    {
        private readonly IConviteAprovacaoApplication _appBase;
        public ConviteAprovacaoController(IConviteAprovacaoApplication appBase) : base(appBase)
        {
            _appBase = appBase;
        }
        [AllowAnonymous]
        public HttpResponseMessage GetByGuid(string id)
        {
            var result = _appBase.Find(x => x.ChaveConfirmacao.ToString().Equals(id)).FirstOrDefault();
            return Request.CreateResponse(System.Net.HttpStatusCode.OK, result);
        }
        [AllowAnonymous]
        public HttpResponseMessage GetConvitesBy(int idDiretor)
        {
            var result = _appBase.Find(x => x.IdDiretor == idDiretor);
            return Request.CreateResponse(System.Net.HttpStatusCode.OK, result.ToArray());
        }

        [HttpPost]
        public HttpResponseMessage ReenviarConvite(int id)
        {
            var result = _appBase.ReenviarConvite(id);

            if (result.IsValid)
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, result);
            return Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, result);

        }
        [AllowAnonymous]
        public override HttpResponseMessage Update(ConviteAprovacao entity)
        {
            return base.Update(entity);
        }
    }
}
