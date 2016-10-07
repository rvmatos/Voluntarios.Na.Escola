using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using VoluntariosNaEscola.AppService.Core.Config;
using VoluntariosNaEscola.AppService.WebApi.Authorization;
using VoluntariosNaEscola.Domain.Interfaces.Application;
using VoluntariosNaEscola.Infra.CrossCutting.InversionOfControl;

namespace VoluntariosNaEscola.AppService.WebApi
{
    public class Startup
    {
        private IKernel _kernel;
        public static HttpConfiguration HttpConfiguration { get; private set; }
        public void Configuration(IAppBuilder app)
        {
            //Global.asax
            HttpConfiguration = new HttpConfiguration();


            //AreaRegistration.RegisterAllAreas();
            //AutoMapperConfig.CreateMaps();



            _kernel = CreateKernel();

            WebApiConfig.Register(HttpConfiguration);
            ConfigureOAuth(app);

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseNinjectMiddleware(() => _kernel).UseNinjectWebApi(HttpConfiguration);
            app.UseWebApi(HttpConfiguration);

        }



        private static IKernel CreateKernel()
        {
            var ioc = new IoC();
            var kernel = ioc.kernel;
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);


                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/api/security/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(8),
                Provider = new AuthorizationServerProvider(_kernel.Get<IUsuarioApplication>())
            };

            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}