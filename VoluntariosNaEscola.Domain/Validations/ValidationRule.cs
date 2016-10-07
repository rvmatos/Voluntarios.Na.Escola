using VoluntariosNaEscola.Domain.Interfaces.Specification;
using VoluntariosNaEscola.Domain.Interfaces.Validation;

namespace VoluntariosNaEscola.Domain.Validations
{
    public class ValidationRule<TEntity> : IValidationRule<TEntity>
    {
        private readonly ISpecification<TEntity> _ruleSpecification;
        public string ErrorMessage
        {
            get; set;
        }

        public ValidationRule(ISpecification<TEntity> ruleSpecification, string errorMessage)
        {
            ErrorMessage = errorMessage;
            _ruleSpecification = ruleSpecification;
        }

        public bool Valid(TEntity entity)
        {
            return _ruleSpecification.IsSatisfiedBy(entity);
        }
    }
}
