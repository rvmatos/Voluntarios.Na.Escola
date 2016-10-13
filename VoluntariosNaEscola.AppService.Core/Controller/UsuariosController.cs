using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using VoluntariosNaEscola.Domain.Entities;
using VoluntariosNaEscola.Domain.Interfaces.Application;
using VoluntariosNaEscola.Domain.Interfaces.AppService;

namespace VoluntariosNaEscola.AppService.Core.Controller
{
    public class UsuariosController : BaseController<Usuario>, IUsuarioAppService
    {
        private readonly IUsuarioApplication _application;
        public UsuariosController(IUsuarioApplication application) : base(application)
        {
            _application = application;
        }

        [HttpGet]
        public HttpResponseMessage Autenticar(string usuario, string senha)
        {
           var result =  _application.Find(x => x.Apelido == usuario && x.Senha == senha).FirstOrDefault();

            if (result != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            return Request.CreateResponse(HttpStatusCode.Forbidden);
        }
    }
}
