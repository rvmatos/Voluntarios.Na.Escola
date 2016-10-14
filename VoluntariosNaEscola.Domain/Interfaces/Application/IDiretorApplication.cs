﻿using System;
using VoluntariosNaEscola.Domain.Entities;
using VoluntariosNaEscola.Domain.Interfaces.Application.Common;

namespace VoluntariosNaEscola.Domain.Interfaces.Application
{
    public interface IDiretorApplication : IDisposable, IApplication<Diretor>
    {
        bool IsDiretor(int id);
    }
}
