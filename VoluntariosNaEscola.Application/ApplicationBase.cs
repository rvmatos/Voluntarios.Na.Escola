using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using VoluntariosNaEscola.Domain.Interfaces.Application.Common;
using VoluntariosNaEscola.Domain.Interfaces.Service.Common;
using VoluntariosNaEscola.Domain.Validations;

namespace VoluntariosNaEscola.Application
{
    public class ApplicationBase<TEntity> : IApplication<TEntity> where TEntity : class
    {
        private readonly IService<TEntity> _serviceBase;

        public ApplicationBase(IService<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }
        public ValidationResult Add(TEntity obj)
        {
            return _serviceBase.Add(obj);
        }

        public ValidationResult Delete(int id)
        {
            return _serviceBase.Delete(id);
        }

        public void Dispose()
        {
            _serviceBase.Dispose();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = false)
        {
            return _serviceBase.Find(predicate, @readonly);
        }

        public TEntity Get(int id)
        {
            return _serviceBase.Get(id);
        }

        public IEnumerable<TEntity> GetAll(bool @readonly = false)
        {
            return _serviceBase.GetAll(@readonly);
        }

        public ValidationResult Update(TEntity obj)
        {
            return _serviceBase.Update(obj);
        }
    }
}
