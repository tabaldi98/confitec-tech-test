using System.Linq.Expressions;

namespace Confitec.Technical.Test.Domain.Contracts.Specification
{
    public sealed class DirectSpecification<TEntity> : Specification<TEntity> where TEntity : class
    {
        private readonly Expression<Func<TEntity, bool>> _matchingCriteria;

        public DirectSpecification(Expression<Func<TEntity, bool>> matchingCriteria)
        {
            _matchingCriteria = matchingCriteria ?? throw new ArgumentNullException(nameof(matchingCriteria));
        }

        public override Expression<Func<TEntity, bool>> SatisfiedBy()
        {
            return _matchingCriteria;
        }
    }
}
