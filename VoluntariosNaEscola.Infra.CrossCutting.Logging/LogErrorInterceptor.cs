using Ninject.Extensions.Interception;
using Serilog;
using System;

namespace VoluntariosNaEscola.Infra.CrossCutting.Logging
{
    public class LogErrorInterceptor : IInterceptor
    {

        private readonly ILogger _logger;

        public LogErrorInterceptor(ILogger logger)
        {

            _logger = logger;
        }

        public void Intercept(IInvocation invocation)
        {

            try
            {

                invocation.Proceed();
            }
            catch (Exception exception)
            {

                _logger.ForContext(invocation.Request.Target.GetType())
                    .Error(exception, "Error at Method: {@Name} Arguments: {@Arguments}",
                        invocation.Request.Method.Name,
                        invocation.Request.Arguments);

                throw;
            }
        }
    }
}
