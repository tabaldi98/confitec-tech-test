using System.Linq.Expressions;

namespace Confitec.Technical.Test.Domain.Contracts.Specification
{
    public abstract class Specification<TEntity> : ISpecification<TEntity> where TEntity : class
    {
        public abstract Expression<Func<TEntity, bool>> SatisfiedBy();
    }
}
