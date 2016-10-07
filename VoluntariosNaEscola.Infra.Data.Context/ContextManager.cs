using VoluntariosNaEscola.Infra.Data.Context.Interfaces;

namespace VoluntariosNaEscola.Infra.Data.Context
{
    public class ContextManager<TContext> : IContextManager<TContext> where TContext : IDbContext, new()
    {
        private const string ContextKey = "ContextManager.Context";

        public IDbContext GetContext()
        {
                    return new TContext();
            
        }

        public void Finish()
        {
            
        }
    }
}
