using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoluntariosNaEscola.Domain.Entities;
using VoluntariosNaEscola.Domain.Interfaces.Application;
using VoluntariosNaEscola.Domain.Interfaces.Service;
using VoluntariosNaEscola.Domain.Validations;

namespace VoluntariosNaEscola.Application
{
    public class ConviteAprovacaoApplication :ApplicationBase<ConviteAprovacao>, IConviteAprovacaoApplication
    {
        private readonly IConviteAprovacaoService _service;
        public ConviteAprovacaoApplication(IConviteAprovacaoService service) : base(service)
        {
            _service = service;
        }

        public ValidationResult ReenviarConvite(int idConviteAprovacao)
        {
            return _service.ReenviarConvite(idConviteAprovacao);
        }
    }
}
