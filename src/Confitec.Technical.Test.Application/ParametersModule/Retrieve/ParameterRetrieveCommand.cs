using FluentValidation;
using MediatR;

namespace Confitec.Technical.Test.Application.ParametersModule.Retrieve
{
    public class ParameterRetrieveCommand : IRequest<ParameterRetrieveModel>
    {
        public int ID { get; set; }
    }

    public class ParameterRetrieveCommandValidator: AbstractValidator<ParameterRetrieveCommand>
    {
        public ParameterRetrieveCommandValidator()
        {
            RuleFor(p => p.ID)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
