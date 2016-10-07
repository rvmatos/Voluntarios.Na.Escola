using Ninject.Extensions.Interception;
using Serilog;

namespace VoluntariosNaEscola.Infra.CrossCutting.Logging
{
    public class LogInterceptor : SimpleInterceptor
    {

        private readonly ILogger _logger;

        public LogInterceptor(ILogger logger)
        {

            _logger = logger;
        }

        protected override void BeforeInvoke(IInvocation invocation)
        {

        }

        protected override void AfterInvoke(IInvocation invocation)
        {

            _logger.ForContext(invocation.Request.Target.GetType())
                .Information("Method: {Name} called with arguments {@Arguments} returned {@ReturnValue}",
                    invocation.Request.Method.Name,
                    invocation.Request.Arguments,
                    invocation.ReturnValue);
        }
    }
}
