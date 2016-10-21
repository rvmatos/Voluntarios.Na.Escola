using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoluntariosNaEscola.Domain.Entities;
using VoluntariosNaEscola.Domain.Interfaces.Repository;
using VoluntariosNaEscola.Infra.Data.Repository.EntityFramework.Common;

namespace VoluntariosNaEscola.Infra.Data.Repository.EntityFramework
{
    public class ConviteAprovacaoRepository : Repository<ConviteAprovacao>, IConviteAprovacaoRepository
    {
    }
}
