namespace Confitec.Technical.Test.Domain.ParametersModule
{
    public interface IParameterRepository
    {
        Task<Parameter> CreateAsync(Parameter parameter);
        Task<List<Parameter>> GetAllAsync();
        Task<bool> UpdateAsync(Parameter parameter);
        Task<Parameter?> GetParameterAsync(int id, bool isTracking = false);
    }
}
