using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using VoluntariosNaEscola.Domain.Validations;

namespace VoluntariosNaEscola.Domain.Interfaces.Application.Common
{
    public interface IApplication<TEntity> where TEntity : class
    {
        ValidationResult Add(TEntity obj);
        ValidationResult Update(TEntity obj);
        ValidationResult Delete(int id);
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll(bool @readonly = false);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = false);

        void Dispose();

    }
}
