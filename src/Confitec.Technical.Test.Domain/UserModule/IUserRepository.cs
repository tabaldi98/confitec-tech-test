﻿using Confitec.Technical.Test.Domain.Contracts.Mappers;
using Confitec.Technical.Test.Domain.Contracts.Specification;

namespace Confitec.Technical.Test.Domain.UserModule
{
    public interface IUserRepository
    {
        IQueryable<TResult> RetrieveOData<TResult>(IHaveMapper<User, TResult> mapper);
        Task<User> CreateAsync(User user);
        Task<bool> UpdateAsync(User user);
        Task<List<User>> GetAllAsync();
        Task<User?> GetAsync(ISpecification<User> specification, bool tracking = false);
        Task<bool> AnyAsync(ISpecification<User> specification);
        Task<bool> DeleteAsync(User user);
        Task<bool> DeleteManyAsync(int[] ids);
    }
}
