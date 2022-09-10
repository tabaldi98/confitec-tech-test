using Confitec.Technical.Test.Domain.Contracts.Specification;
using System.Linq.Expressions;

namespace Confitec.Technical.Test.Domain.Contracts.Mappers
{
    public interface IHaveMapper<TEntity, TResult> where TEntity : class
    {
        Expression<Func<TEntity, TResult>> Selector { get; }
        ISpecification<TEntity> Specification { get; }
    }
}
