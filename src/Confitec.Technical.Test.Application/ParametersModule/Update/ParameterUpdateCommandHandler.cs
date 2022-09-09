using Confitec.Technical.Test.Domain.ParametersModule;
using MediatR;

namespace Confitec.Technical.Test.Application.ParametersModule.Update
{
    public class ParameterUpdateCommandHandler : IRequestHandler<ParameterUpdateCommand, bool>
    {
        private readonly IParameterRepository _parameterRepository;

        public ParameterUpdateCommandHandler(IParameterRepository parameterRepository)
        {
            _parameterRepository = parameterRepository;
        }

        public async Task<bool> Handle(ParameterUpdateCommand request, CancellationToken cancellationToken)
        {
            var parameter = await _parameterRepository.GetParameterAsync(request.ID, true);
            if (parameter == null) { throw new InvalidDataException("Parameter not found!"); }

            parameter.UpdateValue(request.Value);

            return await _parameterRepository.UpdateAsync(parameter);
        }
    }
}
