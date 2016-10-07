using Ninject.Modules;
using VoluntariosNaEscola.Application;
using VoluntariosNaEscola.Domain.Interfaces.Application;

namespace VoluntariosNaEscola.Infra.CrossCutting.InversionOfControl.Modules
{
    public class ApplicationModule : NinjectModule
    {

        public override void Load()
        {
            Bind<IUsuarioApplication>().To<UsuarioApplication>();
            Bind<IAcaoApplication>().To<AcaoApplication>();
            Bind<IDiretorApplication>().To<DiretorApplication>();
            Bind<IEnderecoApplication>().To<EnderecoApplication>();
            Bind<IEscolaApplication>().To<EscolaApplication>();
            Bind<IEventoApplication>().To<EventoApplication>();
            Bind<IHabilidadeApplication>().To<HabilidadeApplication>();
            Bind<ISupervisorApplication>().To<SupervisorApplication>();
            Bind<IVoluntarioApplication>().To<VoluntarioApplication>();
        }
    }
}
