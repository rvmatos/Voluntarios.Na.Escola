using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VoluntariosNaEscola.Domain.Entities;
using VoluntariosNaEscola.Domain.Interfaces.Application;
using VoluntariosNaEscola.Domain.Interfaces.AppService;

namespace VoluntariosNaEscola.AppService.Core.Controller
{
    public class DiretoresController : BaseController<Diretor>, IDiretorAppService
    {
        private readonly IDiretorApplication _app;
        public DiretoresController(IDiretorApplication app) : base(app)
        {
            _app = app;
        }

        public HttpResponseMessage AprovarDiretor(int id)
        {
            var diretor = _app.Get(id);
            diretor.Aprovadores.ToList().ForEach(x =>
            {
                x.DiretorAprovado = true;
            });

            diretor.Aprovado = true;

            _app.Update(diretor);
            return Request.CreateResponse(System.Net.HttpStatusCode.OK);


        }
    }
}