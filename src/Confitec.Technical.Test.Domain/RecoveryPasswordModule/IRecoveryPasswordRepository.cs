using Confitec.Technical.Test.Domain.Contracts.Specification;

namespace Confitec.Technical.Test.Domain.RecoveryPasswordModule
{
    public interface IRecoveryPasswordRepository
    {
        Task<RecoveryPassword> CreateAsync(RecoveryPassword recoveryPassword);
        Task<RecoveryPassword> UpdateAsync(RecoveryPassword recoveryPassword);
        Task<RecoveryPassword?> RetrieveAsync(ISpecification<RecoveryPassword> specification);
    }
}
