using Confitec.Technical.Test.Domain.Contracts.Specification;

namespace Confitec.Technical.Test.Domain.SystemUserModule
{
    public interface ISystemUserRepository
    {
        Task<SystemUser?> GetAsync(ISpecification<SystemUser> specification, bool tracking = false);
        Task<bool> AnyAsync(ISpecification<SystemUser> specification);
        Task<SystemUser> CreateAsync(SystemUser user);
        Task<SystemUser> UpdateAsync(SystemUser user);
    }
}
