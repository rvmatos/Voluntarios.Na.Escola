using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VoluntariosNaEscola.Domain.Entities.Validation;

namespace VoluntariosNaEscola.Domain.Interfaces.Service.Common
{
    public interface IService<TEntity> where TEntity : class
    {
        ValidationResult Add(TEntity entity);

        ValidationResult Update(TEntity entity);

        ValidationResult Remove(TEntity entity);

        IEnumerable<TEntity> GetAll(bool @readonly = false);

        TEntity GetById(int idEntity);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = false);
    }
}
