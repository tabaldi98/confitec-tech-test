using System.Linq.Expressions;

namespace Confitec.Technical.Test.Domain.Contracts.Specification
{
    public interface ISpecification<TEntity> where TEntity : class
    {
        Expression<Func<TEntity, bool>> SatisfiedBy();
    }
}
