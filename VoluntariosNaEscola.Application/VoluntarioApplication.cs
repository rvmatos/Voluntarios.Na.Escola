﻿using System;
using VoluntariosNaEscola.Domain.Entities;
using VoluntariosNaEscola.Domain.Interfaces.Application;
using VoluntariosNaEscola.Domain.Interfaces.Service;
using VoluntariosNaEscola.Domain.Validations;

namespace VoluntariosNaEscola.Application
{
    public class VoluntarioApplication : ApplicationBase<Voluntario>, IVoluntarioApplication
    {
        private readonly IVoluntarioService _service;
        public VoluntarioApplication(IVoluntarioService service) : base(service)
        {
            _service = service;
        }


        public bool IsVoluntario(int id)
        {
            try
            {
                return _service.Get(id) != null;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public ValidationResult VincularEscola(int idEscola, int idVoluntario)
        {
            return _service.VincularEscola(idEscola, idVoluntario);
        }
    }
}

