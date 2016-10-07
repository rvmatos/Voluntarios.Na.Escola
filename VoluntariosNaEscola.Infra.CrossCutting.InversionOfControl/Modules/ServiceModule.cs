using Ninject.Modules;
using VoluntariosNaEscola.Domain.Interfaces.Service;
using VoluntariosNaEscola.Domain.Services;

namespace VoluntariosNaEscola.Infra.CrossCutting.InversionOfControl.Modules
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUsuarioService>().To<UsuarioService>();
            Bind<IAcaoService>().To<AcaoService>();
            Bind<IDiretorService>().To<DiretorService>();
            Bind<IEnderecoService>().To<EnderecoService>();
            Bind<IEscolaService>().To<EscolaService>();
            Bind<IEventoService>().To<EventoService>();
            Bind<IHabilidadeService>().To<HabilidadeService>();
            Bind<ISupervisorService>().To<SupervisorService>();
            Bind<IVoluntarioService>().To<VoluntarioService>();
                //.Intercept().With<LogInterceptor>(); 
        }
    }
}
