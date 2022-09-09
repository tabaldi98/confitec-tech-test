using Confitec.Technical.Test.Domain.ParametersModule;
using MediatR;

namespace Confitec.Technical.Test.Application.ParametersModule.Retrieve
{
    public class ParameterRetrieveCommandHandler : IRequestHandler<ParameterRetrieveCommand, ParameterRetrieveModel>
    {
        private readonly IParameterRepository _parameterRepository;

        public ParameterRetrieveCommandHandler(IParameterRepository parameterRepository)
        {
            _parameterRepository = parameterRepository;
        }

        public async Task<ParameterRetrieveModel> Handle(ParameterRetrieveCommand request, CancellationToken cancellationToken)
        {
            var parameter = await _parameterRepository.GetParameterAsync(request.ID);
            if (parameter == null) { throw new InvalidDataException("Parameter not found!"); }

            return new ParameterRetrieveModel()
            {
                ID = parameter.ID,
                Key = parameter.Key,
                Value = parameter.Value
            };
        }
    }
}
