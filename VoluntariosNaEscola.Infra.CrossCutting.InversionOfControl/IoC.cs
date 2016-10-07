using CommonServiceLocator.NinjectAdapter.Unofficial;
using Microsoft.Practices.ServiceLocation;
using Ninject;
using VoluntariosNaEscola.Infra.CrossCutting.InversionOfControl.Modules;

namespace VoluntariosNaEscola.Infra.CrossCutting.InversionOfControl
{
    public class IoC
    {
        public IKernel kernel;

        public IoC()
        {
            kernel = GetNinjectModules();
            ServiceLocator.SetLocatorProvider(() => new NinjectServiceLocator(kernel));
        }

        private StandardKernel GetNinjectModules()
        {
            return new StandardKernel(
                             new ApplicationModule(),
                             new RepositoryModule(),
                             //new AppServiceModule(),
                             new ServiceModule()
                );
        }
    }
}
