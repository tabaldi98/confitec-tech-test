using Confitec.Technical.Test.Domain.Contracts.Mappers;
using Confitec.Technical.Test.Domain.Contracts.Specification;
using Confitec.Technical.Test.Domain.UserModule;
using Microsoft.EntityFrameworkCore;

namespace Confitec.Technical.Test.Infra.Data.UserModule
{
    public class UserRepository : IUserRepository
    {
        private readonly TechnicalTestContext _context;

        public UserRepository(TechnicalTestContext technicalTestContext)
        {
            _context = technicalTestContext;
        }

        public IQueryable<TResult> RetrieveOData<TResult>(IHaveMapper<User, TResult> mapper)
        {
            var specifiedEntities = mapper.Specification == null ? _context.Users.AsNoTracking() : _context.Users.AsNoTracking().Where(mapper.Specification.SatisfiedBy());

            return specifiedEntities.Select(mapper.Selector);
        }

        public Task<bool> AnyAsync(ISpecification<User> specification)
        {
            return _context.Users.AsNoTracking().AnyAsync(specification.SatisfiedBy());
        }

        public async Task<User> CreateAsync(User user)
        {
            var userAdded = await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return userAdded.Entity;
        }

        public Task<List<User>> GetAllAsync()
        {
            return _context.Users.AsNoTracking().OrderBy(p => p.Name).ThenBy(p => p.Surname).ToListAsync();
        }

        public Task<User?> GetAsync(ISpecification<User> specification, bool tracking = false)
        {
            return tracking ?
                 _context.Users.FirstOrDefaultAsync(specification.SatisfiedBy()) :
                 _context.Users.AsNoTracking().FirstOrDefaultAsync(specification.SatisfiedBy());
        }

        public async Task<bool> DeleteAsync(User user)
        {
            _context.Users.Remove(user);

            var rows = await _context.SaveChangesAsync();

            return rows > 0;
        }

        public async Task<bool> UpdateAsync(User user)
        {
            _context.Users.Update(user);

            var rows = await _context.SaveChangesAsync();

            return rows > 0;
        }

        public async Task<bool> DeleteManyAsync(int[] ids)
        {
            _context.Users.RemoveRange(_context.Users.Where(p => ids.Contains(p.ID)));

            var rows = await _context.SaveChangesAsync();

            return rows > 0;
        }
    }
}
