using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoluntariosNaEscola.Domain.Entities;
using VoluntariosNaEscola.Domain.Interfaces.Application.Common;
using VoluntariosNaEscola.Domain.Validations;

namespace VoluntariosNaEscola.Domain.Interfaces.Application
{
    public interface IConviteAprovacaoApplication : IApplication<ConviteAprovacao>
    {
        ValidationResult ReenviarConvite(int idConviteAprovacao);


    }
}
