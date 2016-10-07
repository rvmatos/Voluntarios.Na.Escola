using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace VoluntariosNaEscola.Domain.Interfaces.Repository.Common
{
    public interface IReadOnlyRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll(bool @readonly = false);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = false);
    }
}
