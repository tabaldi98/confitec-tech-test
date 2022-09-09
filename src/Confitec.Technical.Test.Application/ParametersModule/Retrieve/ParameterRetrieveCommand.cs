using FluentValidation;
using MediatR;

namespace Confitec.Technical.Test.Application.ParametersModule.Retrieve
{
    public class ParameterRetrieveCommand : IRequest<ParameterRetrieveModel>
    {
        public int ID { get; set; }

        public ParameterRetrieveCommand()
        { }

        public ParameterRetrieveCommand(int id)
        {
            ID = id;
        }
    }

    public class ParameterRetrieveCommandValidator : AbstractValidator<ParameterRetrieveCommand>
    {
        public ParameterRetrieveCommandValidator()
        {
            RuleFor(p => p.ID)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
