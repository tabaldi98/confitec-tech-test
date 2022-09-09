using MediatR;

namespace Confitec.Technical.Test.Application.ParametersModule.Retrieve
{
    public class ParameterRetrieveAllCommand : IRequest<IEnumerable<ParameterRetrieveAllModel>>
    { }
}
