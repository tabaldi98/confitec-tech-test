using Confitec.Technical.Test.Domain.ParametersModule;
using MediatR;

namespace Confitec.Technical.Test.Application.ParametersModule.Retrieve
{
    public class ParameterRetrieveAllCommandHandler : IRequestHandler<ParameterRetrieveAllCommand, IEnumerable<ParameterRetrieveAllModel>>
    {
        private readonly IParameterRepository _parameterRepository;

        public ParameterRetrieveAllCommandHandler(IParameterRepository parameterRepository)
        {
            _parameterRepository = parameterRepository;
        }

        public async Task<IEnumerable<ParameterRetrieveAllModel>> Handle(ParameterRetrieveAllCommand request, CancellationToken cancellationToken)
        {
            var all = await _parameterRepository.GetAllAsync();

            return all.Select(p => new ParameterRetrieveAllModel()
            {
                ID = p.ID,
                Key = p.Key,
                Value = p.Value
            });
        }
    }
}
