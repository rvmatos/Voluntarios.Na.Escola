﻿using System;
using VoluntariosNaEscola.Domain.Entities;
using VoluntariosNaEscola.Domain.Interfaces.Repository.Common;

namespace VoluntariosNaEscola.Domain.Interfaces.Repository
{
    public interface IAcaoRepository : IDisposable, IRepository<Acao>
    {
    }
}
