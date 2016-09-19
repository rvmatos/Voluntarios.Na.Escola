using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VoluntariosNaEscola.Domain.Entities.Validation;
using VoluntariosNaEscola.Domain.Interfaces.Repository.Common;
using VoluntariosNaEscola.Domain.Interfaces.Service.Common;

namespace VoluntariosNaEscola.Domain.Services.Common
{
    public class ServiceBase<TEntity> : IService<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> _repo;
        public ValidationResult _validation;

        public ServiceBase(IRepository<TEntity> repo)
        {
            _repo = repo;
            _validation = new ValidationResult();
        }
        public ValidationResult Add(TEntity entity)
        {
            try
            {
                _repo.Add(entity);
            }
            catch (Exception)
            {
                
            }
            return _validation;
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = false)
        {
            return _repo.Find(predicate);
        }

        public IEnumerable<TEntity> GetAll(bool @readonly = false)
        {
            return _repo.GetAll(@readonly);
        }

        public TEntity GetById(int idEntity)
        {
            return _repo.GetById(idEntity);
        }

        public ValidationResult Remove(TEntity entity)
        {
            try
            {
                _repo.Remove(entity);
            }
            catch (Exception)
            {

            }
            return _validation;
        }

        public ValidationResult Update(TEntity entity)
        {
            try
            {
                _repo.Update(entity);
            }
            catch (Exception)
            {

            }
            return _validation;
        }
    }
}
