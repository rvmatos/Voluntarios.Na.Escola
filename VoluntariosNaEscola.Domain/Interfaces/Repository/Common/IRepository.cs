using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VoluntariosNaEscola.Domain.Entities.Validation;

namespace VoluntariosNaEscola.Domain.Interfaces.Repository.Common
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        void Update(TEntity entity);

        void Remove(TEntity entity);

        IEnumerable<TEntity> GetAll(bool @readonly = false);

        TEntity GetById(int idEntity);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = false);

    }
}
