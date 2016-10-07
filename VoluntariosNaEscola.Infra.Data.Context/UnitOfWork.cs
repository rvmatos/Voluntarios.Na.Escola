using Microsoft.Practices.ServiceLocation;
using System;
using VoluntariosNaEscola.Infra.Data.Context.Interfaces;

namespace VoluntariosNaEscola.Infra.Data.Context
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext>, IDisposable where TContext : IDbContext, new()
    {
        private readonly ContextManager<TContext> _contextManager =
            ServiceLocator.Current.GetInstance<IContextManager<TContext>>() as ContextManager<TContext>;

        private readonly IDbContext _dbContext;

        private bool _disposed;

        public UnitOfWork()
        {
            _dbContext = _contextManager.GetContext();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void BeginTransaction()
        {
            _disposed = false;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

    }


}
