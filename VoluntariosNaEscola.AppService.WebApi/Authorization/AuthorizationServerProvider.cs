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

        public AuthorizationServerProvider(IUsuarioApplication usuarioApp)
        {
            _usuarioApp = usuarioApp;
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
                var usuario = await Task.Run(() => _usuarioApp.Find(x => x.Email == user && x.Senha == password).FirstOrDefault());
                if (usuario == null)
                {
                    context.SetError("404", "Usuário ou senha inválidos");
                    return;
                }

                var props = new AuthenticationProperties(new Dictionary<string, string>
                {
                    {
                        "username", usuario.Email
                    },
                    {
                        "userid", usuario.Id.ToString()
                    },
                    {
                       "name", usuario.Nome
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