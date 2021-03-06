﻿using System;
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
    public class EscolasController : BaseController<Escola>, IEscolaAppService
    {
        private readonly IEscolaApplication _app;
        public EscolasController(IEscolaApplication app) : base(app)
        {
            _app = app;
        }

        [AllowAnonymous]
        public override HttpResponseMessage Add(Escola entity)
        {
            return base.Add(entity);
        }

        [HttpGet]
        public Escola GetByDiretor(int idDiretor)
        {
           return  _app.Find(x => x.IdDiretor == idDiretor).FirstOrDefault();
        }
    }
}
