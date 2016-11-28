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
    public class EventosController : BaseController<Evento>, IEventoAppService
    {
        private readonly IEventoApplication _app;
        public EventosController(IEventoApplication app) : base(app)
        {
            _app = app;
        }

        public override HttpResponseMessage Add(Evento entity)
        {
            entity.Criador = new Usuario();
            entity.Criador.Id = IdUserLogged;
            return base.Add(entity);        
        }

        public HttpResponseMessage GetByIdEscola(int id)
        {
           var result = _app.Find(x => x.IdEscola == id).ToList();
           return Request.CreateResponse(System.Net.HttpStatusCode.OK, result);
        }
    }
}