using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using VoluntariosNaEscola.Domain.Entities;
using VoluntariosNaEscola.Domain.Interfaces.Application;
using VoluntariosNaEscola.Domain.Interfaces.AppService;

namespace VoluntariosNaEscola.AppService.Core.Controller
{
    [Authorize]
    public class VoluntariosController : BaseController<Voluntario>, IVoluntarioAppService
    {
        private readonly IVoluntarioApplication _app;
        private readonly IEscolaApplication _appEscola;
        public VoluntariosController(IVoluntarioApplication app, IEscolaApplication appEscola) : base(app)
        {
            _app = app;
            _appEscola = appEscola;
        }

        [AllowAnonymous]
        public override HttpResponseMessage Add(Voluntario entity)
        {
            return base.Add(entity);
        }


        public HttpResponseMessage VincularEscola(int idEscola, int idVoluntario)
        {
            var voluntario = _app.Get(idVoluntario);
            var result = _app.VincularEscola(idEscola, idVoluntario);

            return Request.CreateResponse(System.Net.HttpStatusCode.OK, result);

        }
    }
}
