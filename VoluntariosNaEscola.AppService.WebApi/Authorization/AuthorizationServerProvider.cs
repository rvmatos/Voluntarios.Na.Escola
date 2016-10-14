using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using VoluntariosNaEscola.Domain.Interfaces.Application;

namespace VoluntariosNaEscola.AppService.WebApi.Authorization
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly IUsuarioApplication _usuarioApp;
        private readonly ISupervisorApplication  _supervisorApp;
        private readonly IDiretorApplication _diretorApp;
        private readonly IVoluntarioApplication _voluntarioApp;

        public AuthorizationServerProvider(IUsuarioApplication usuarioApp, ISupervisorApplication supervisorApp,
                                           IDiretorApplication diretorApp, IVoluntarioApplication voluntarioApp)
        {
            _usuarioApp = usuarioApp;
            _supervisorApp = supervisorApp;
            _diretorApp = diretorApp;
            _voluntarioApp = voluntarioApp;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            await Task.Run(() => context.Validated());
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            try
            {
                context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
                var user = context.UserName;
                var password = context.Password;
                var usuario = await Task.Run(() => _usuarioApp.Find(x => x.Apelido == user && x.Senha == password).FirstOrDefault());
                if (usuario == null)
                {
                    context.SetError("404", "Usuário ou senha inválidos");
                    return;
                }


                bool isSupervisor = _supervisorApp.IsSupervisor(usuario.Id);
                bool isDiretor = _diretorApp.IsDiretor(usuario.Id);
                bool isVoluntario = _voluntarioApp.IsVoluntario(usuario.Id);

                var props = new AuthenticationProperties(new Dictionary<string, string>
                {
                    {
                        "username", usuario.Apelido
                    },
                    {
                        "userid", usuario.Id.ToString()
                    },
                    {
                       "name", usuario.Nome
                    },
                    {
                        "isAdmin", (!isSupervisor && !isDiretor && !isVoluntario).ToString()
                    },
                    {
                        "isSupervisor", (isSupervisor).ToString()
                    },
                    {
                        "isDiretor", (isDiretor).ToString()
                    },
                    {
                        "isVoluntario", (isVoluntario).ToString()
                    }


                });


                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Name, usuario.Nome));
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, usuario.Email));
                identity.AddClaim(new Claim(ClaimTypes.PrimarySid, usuario.Id.ToString()));

                var roles = new List<string>();

                //usuario.GrupoUsuario.AsParallel().ForAll(grupo => { roles.Add(grupo.Grupo.Nome); });
                //roles.Add(usuario.Grupo.Nome);
                GenericPrincipal principal = new GenericPrincipal(identity, roles.ToArray());
                var ticket = new AuthenticationTicket(identity, props);
                Thread.CurrentPrincipal = principal;
                context.Validated(ticket);

            }
            catch (Exception ex)
            {
                // _log.ErrorFormat("{0} - {1}", ex.Message, ex);
                context.SetError("500", "Falha ao autenticar");
            }
        }

        public override System.Threading.Tasks.Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return base.TokenEndpoint(context);
        }
    }
}