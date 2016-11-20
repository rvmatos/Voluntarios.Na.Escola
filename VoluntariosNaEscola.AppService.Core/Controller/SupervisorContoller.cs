﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoluntariosNaEscola.Domain.Entities;
using VoluntariosNaEscola.Domain.Interfaces.Application;
using VoluntariosNaEscola.Domain.Interfaces.AppService;

namespace VoluntariosNaEscola.AppService.Core.Controller
{
    public class SupervisorController : BaseController<Supervisor>, ISupervisorAppService
    {
        private readonly ISupervisorApplication _app;
        public SupervisorController(ISupervisorApplication app) : base(app)
        {
            _app = app;
        }
    }
}
