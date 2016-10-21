using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using VoluntariosNaEscola.Domain.Interfaces.Repository.Common;
using VoluntariosNaEscola.Domain.Interfaces.Service.Common;
using VoluntariosNaEscola.Domain.Validations;

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
        public virtual ValidationResult Add(TEntity entity)
        {
            try
            {
                if (_validation.IsValid)
                {
                    _repo.Add(entity);
                    _validation.Model = entity;
                }
            }
            catch (Exception ex)
            {
                _validation.Add(ex.Message, "Erro ao adicionar entidade", ex.StackTrace);
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

        public TEntity Get(int idEntity)
        {
            return _repo.Get(idEntity);
        }

        public ValidationResult Delete(int id)
        {
            try
            {
                _repo.Delete(Get(id));
            }
            catch (Exception ex)
            {
                _validation.Add(ex.Message, "Erro ao deletar entidade", ex.StackTrace);
            }
            return _validation;
        }

        public ValidationResult Update(TEntity entity)
        {
            try
            {
                if (_validation.IsValid)
                    _repo.Update(entity);
                _validation.Model = entity;
            }
            catch (Exception ex)
            {
                _validation.Add(ex.Message, "Erro ao atualizar entidade", ex.StackTrace);
            }
            return _validation;
        }

        public void Dispose()
        {
            _repo.Dispose();
        }
    }
}
