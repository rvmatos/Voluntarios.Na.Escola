using Ninject.Extensions.Interception;
using Serilog;

namespace VoluntariosNaEscola.Infra.CrossCutting.Logging
{
    public class TimerInterceptor : IInterceptor
    {

        private readonly string _timerName;
        private readonly ILogger _logger;

        public TimerInterceptor(string timerName, ILogger logger)
        {

            _timerName = timerName;
            _logger = logger;
        }

        public void Intercept(IInvocation invocation)
        {

            using (_logger.ForContext(invocation.Request.Target.GetType())
                .BeginTimedOperation(_timerName, invocation.Request.Method.Name))
            {
                invocation.Proceed();
            }
        }
    }
}
