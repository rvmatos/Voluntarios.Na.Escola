using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoluntariosNaEscola.Domain.Entities;
using VoluntariosNaEscola.Domain.Interfaces.Service.Common;
using VoluntariosNaEscola.Domain.Validations;

namespace VoluntariosNaEscola.Domain.Interfaces.Service
{
    public interface IConviteAprovacaoService : IService<ConviteAprovacao>
    {
        ValidationResult ReenviarConvite(int idConviteAprovacao);
    }
}
