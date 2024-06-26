﻿using Confitec.Technical.Test.Domain.Contracts.Mappers;
using Confitec.Technical.Test.Domain.Contracts.Specification;
using Confitec.Technical.Test.Domain.SystemUserModule;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Confitec.Technical.Test.Infra.Data.UserModule
{
    public class SystemUserRepository : ISystemUserRepository
    {
        private readonly TechnicalTestContext _context;

        public SystemUserRepository(TechnicalTestContext technicalTestContext)
        {
            _context = technicalTestContext;
        }

        public IQueryable<TResult> RetrieveOData<TResult>(IHaveMapper<SystemUser, TResult> mapper)
        {
            var specifiedEntities = mapper.Specification == null ? _context.SystemUsers.AsNoTracking() : _context.SystemUsers.AsNoTracking().Where(mapper.Specification.SatisfiedBy());

            return specifiedEntities.Select(mapper.Selector);
        }

        public Task<SystemUser?> GetAsync(ISpecification<SystemUser> specification, bool tracking = false, params Expression<Func<SystemUser, object>>[] includeExpressions)
        {
            var users = tracking ? _context.SystemUsers : _context.SystemUsers.AsNoTracking();

            if (includeExpressions.Any())
            {
                users = includeExpressions.Aggregate<Expression<Func<SystemUser, object>>, IQueryable<SystemUser>>(_context.SystemUsers, (current, expression) => current.Include(expression));
            }

            return users.FirstOrDefaultAsync(specification.SatisfiedBy());
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

        public async Task<SystemUser> UpdateAsync(SystemUser user)
        {
            var userAdded = _context.SystemUsers.Update(user);
            await _context.SaveChangesAsync();

            return userAdded.Entity;
        }

        public async Task<bool> DeleteManyAsync(int[] ids)
        {
            _context.SystemUsers.RemoveRange(_context.SystemUsers.Where(p => ids.Contains(p.ID)));

            var rows = await _context.SaveChangesAsync();

            return rows > 0;
        }
    }
}
