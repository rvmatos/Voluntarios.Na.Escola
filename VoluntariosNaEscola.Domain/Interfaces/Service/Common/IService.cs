using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using VoluntariosNaEscola.Domain.Validations;

namespace VoluntariosNaEscola.Domain.Interfaces.Service.Common
{
    public interface IService<TEntity> where TEntity : class
    {
        ValidationResult Add(TEntity entity);

        ValidationResult Update(TEntity entity);

        ValidationResult Delete(int id);

        IEnumerable<TEntity> GetAll(bool @readonly = false);

        TEntity Get(int idEntity);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = false);

        void Dispose();

    }
}
