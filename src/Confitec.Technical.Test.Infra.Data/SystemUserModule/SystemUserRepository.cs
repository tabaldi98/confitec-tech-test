using Confitec.Technical.Test.Domain.Contracts.Specification;
using Confitec.Technical.Test.Domain.SystemUserModule;
using Microsoft.EntityFrameworkCore;

namespace Confitec.Technical.Test.Infra.Data.UserModule
{
    public class SystemUserRepository : ISystemUserRepository
    {
        private readonly TechnicalTestContext _context;

        public SystemUserRepository(TechnicalTestContext technicalTestContext)
        {
            _context = technicalTestContext;
        }

        public Task<SystemUser?> GetAsync(ISpecification<SystemUser> specification, bool tracking = false)
        {
            return tracking ?
                 _context.SystemUsers.FirstOrDefaultAsync(specification.SatisfiedBy()) :
                 _context.SystemUsers.AsNoTracking().FirstOrDefaultAsync(specification.SatisfiedBy());
        }

        public Task<bool> AnyAsync(ISpecification<SystemUser> specification)
        {
            return _context.SystemUsers.AsNoTracking().AnyAsync(specification.SatisfiedBy());
        }

        public async Task<SystemUser> CreateAsync(SystemUser user)
        {
            var userAdded = await _context.SystemUsers.AddAsync(user);
            await _context.SaveChangesAsync();

            return userAdded.Entity;
        }
    }
}
