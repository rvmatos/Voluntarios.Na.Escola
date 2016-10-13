using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using VoluntariosNaEscola.Domain.Interfaces.Repository.Common;
using VoluntariosNaEscola.Infra.Data.Context;

namespace VoluntariosNaEscola.Infra.Data.Repository.EntityFramework.Common
{
    public class Repository<TEntity> : IRepository<TEntity>, IDisposable where TEntity : class
    {
        private readonly VoluntariadoContext _dbContext;

        private readonly IDbSet<TEntity> _dbSet;

        public Repository()
        {        

            _dbContext = new VoluntariadoContext();
            _dbSet = _dbContext.Set<TEntity>();
        }

        protected VoluntariadoContext Context { get { return _dbContext; } }

        protected IDbSet<TEntity> DbSet { get { return _dbSet; } }

        public virtual void Add(TEntity entity)
        {
            DbSet.Add(entity);
            Context.SaveChanges();
        }

        public virtual void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
            Context.SaveChanges();
        }

        public virtual TEntity Get(int id)
        {
            var entity = DbSet.Find(id);
            return entity;
        }

        public virtual void Update(TEntity entity)
        {
            var entry = Context.Entry(entity);
            DbSet.Attach(entity);
            entry.State = EntityState.Modified;
            Context.SaveChanges();
            //Context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public virtual IEnumerable<TEntity> GetAll(bool @readonly = false)
        {
            return @readonly ? DbSet.AsNoTracking().ToList() : DbSet.ToList();
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = false)
        {
            return @readonly ? DbSet.Where(predicate).AsNoTracking() : DbSet.Where(predicate);
        }

        #region Dispose

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;

            if (Context == null) return;
            Context.Dispose();
        }

        #endregion

    }
}

