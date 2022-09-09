using Confitec.Technical.Test.Domain.Contracts.Specification;
using Confitec.Technical.Test.Domain.RecoveryPasswordModule;
using Microsoft.EntityFrameworkCore;

namespace Confitec.Technical.Test.Infra.Data.RecoveryPasswordModule
{
    public class RecoveryPasswordRepository : IRecoveryPasswordRepository
    {
        private readonly TechnicalTestContext _context;

        public RecoveryPasswordRepository(TechnicalTestContext technicalTestContext)
        {
            _context = technicalTestContext;
        }

        public async Task<RecoveryPassword> CreateAsync(RecoveryPassword recoveryPassword)
        {
            var userAdded = await _context.RecoveryPassword.AddAsync(recoveryPassword);
            await _context.SaveChangesAsync();

            return userAdded.Entity;
        }

        public async Task<RecoveryPassword> UpdateAsync(RecoveryPassword recoveryPassword)
        {
            var recoveryUpdate = _context.RecoveryPassword.Update(recoveryPassword);
            await _context.SaveChangesAsync();

            return recoveryUpdate.Entity;
        }

        public Task<RecoveryPassword?> RetrieveAsync(ISpecification<RecoveryPassword> specification)
        {
            return _context.RecoveryPassword.FirstOrDefaultAsync(specification.SatisfiedBy());
        }
    }
}
