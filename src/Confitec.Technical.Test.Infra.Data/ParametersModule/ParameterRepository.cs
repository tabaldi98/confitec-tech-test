using Confitec.Technical.Test.Domain.ParametersModule;
using Microsoft.EntityFrameworkCore;

namespace Confitec.Technical.Test.Infra.Data.ParametersModule
{
    public class ParameterRepository : IParameterRepository
    {
        private readonly TechnicalTestContext _context;

        public ParameterRepository(TechnicalTestContext technicalTestContext)
        {
            _context = technicalTestContext;
        }

        public async Task<Parameter> CreateAsync(Parameter parameter)
        {
            var parameterAdded = await _context.Parameters.AddAsync(parameter);
            await _context.SaveChangesAsync();

            return parameterAdded.Entity;
        }

        public Task<List<Parameter>> GetAllAsync()
        {
            return _context.Parameters.AsNoTracking().ToListAsync();
        }

        public Task<Parameter?> GetParameterAsync(int id, bool isTracking = false)
        {
            return isTracking ?
                 _context.Parameters.FirstOrDefaultAsync(p => p.ID == id) :
                 _context.Parameters.AsNoTracking().FirstOrDefaultAsync(p => p.ID == id);
        }

        public async Task<bool> UpdateAsync(Parameter parameter)
        {
            _context.Parameters.Update(parameter);

            var rows = await _context.SaveChangesAsync();

            return rows > 0;
        }
    }
}
