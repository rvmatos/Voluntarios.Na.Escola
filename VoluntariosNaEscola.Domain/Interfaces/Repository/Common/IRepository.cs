using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace VoluntariosNaEscola.Domain.Interfaces.Repository.Common
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Delete(TEntity obj);
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll(bool @readonly = false);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = false);

        void Dispose();

    }
}
