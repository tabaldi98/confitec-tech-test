using Confitec.Technical.Test.Domain.Contracts.Mappers;
using Confitec.Technical.Test.Domain.Contracts.Specification;
using System.Linq.Expressions;

namespace Confitec.Technical.Test.Domain.SystemUserModule
{
    public interface ISystemUserRepository
    {
        Task<SystemUser?> GetAsync(ISpecification<SystemUser> specification, bool tracking = false, params Expression<Func<SystemUser, object>>[] includeExpressions);
        Task<bool> AnyAsync(ISpecification<SystemUser> specification);
        Task<SystemUser> CreateAsync(SystemUser user);
        Task<SystemUser> UpdateAsync(SystemUser user);
        IQueryable<TResult> RetrieveOData<TResult>(IHaveMapper<SystemUser, TResult> mapper);
        Task<bool> DeleteManyAsync(int[] ids);
    }
}
