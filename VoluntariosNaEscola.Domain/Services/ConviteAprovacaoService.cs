using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoluntarioNaEscola.Infra.CrossCutting.Util.Mail;
using VoluntariosNaEscola.Domain.Entities;
using VoluntariosNaEscola.Domain.Entities.Validation;
using VoluntariosNaEscola.Domain.Interfaces.Repository;
using VoluntariosNaEscola.Domain.Interfaces.Service;
using VoluntariosNaEscola.Domain.Services.Common;
using VoluntariosNaEscola.Domain.Validations;

namespace VoluntariosNaEscola.Domain.Services
{
    public class ConviteAprovacaoService : ServiceBase<ConviteAprovacao>, IConviteAprovacaoService
    {
        private readonly IConviteAprovacaoRepository _repository;
        private readonly IEscolaRepository _escola;
        public ConviteAprovacaoService(IConviteAprovacaoRepository repository, IEscolaRepository escola) : base(repository)
        {
            _repository = repository;
            _escola = escola;
        }

        public override ValidationResult Add(ConviteAprovacao entity)
        {
            entity.ChaveConfirmacao = Guid.NewGuid();
            var result = base.Add(entity);
            if (result.IsValid)
            {
                var objEscola = _escola.Find(x => x.IdDiretor == entity.IdDiretor).FirstOrDefault();
                string body = string.Format(MessageResource.MsgCorpoEmailConviteAprovador, entity.ChaveConfirmacao, objEscola.Nome, objEscola.Diretor.Nome, ConfigurationManager.AppSettings["UrlConviteAprovador"]);
                MailService mail = new MailService();
                Task t = Task.Run(() => mail.SendEmail(entity.Email, MessageResource.MsgAssuntoEmailConviteAprovador, body));
                Task.Run(() =>
                {
                    t.Wait();
                    entity.DtEnvio = DateTime.Now;
                    base.Update(entity);
                });
            }

            return result;
        }

        public ValidationResult ReenviarConvite(int idConviteAprovacao)
        {
            var entity = _repository.Get(idConviteAprovacao);
            var objEscola = _escola.Find(x => x.IdDiretor == entity.IdDiretor).FirstOrDefault();
            string body = string.Format(MessageResource.MsgCorpoEmailConviteAprovador, entity.ChaveConfirmacao, objEscola.Nome, objEscola.Diretor.Nome, ConfigurationManager.AppSettings["UrlConviteAprovador"]);
            MailService mail = new MailService();
            Task t = Task.Run(() => mail.SendEmail(entity.Email, MessageResource.MsgAssuntoEmailConviteAprovador, body));

            t.Wait();
            entity.DtEnvio = DateTime.Now;
            



            return base.Update(entity);
        }
    }
}
