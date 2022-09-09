using FluentValidation;
using MediatR;

namespace Confitec.Technical.Test.Application.ParametersModule.Update
{
    public class ParameterUpdateCommand : IRequest<bool>
    {
        public int ID { get; set; }
        public string Value { get; set; }
    }

    public class ParameterUpdateCommandValidator : AbstractValidator<ParameterUpdateCommand>
    {
        public ParameterUpdateCommandValidator()
        {
            RuleFor(p => p.ID)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(p => p.Value)
                .NotEmpty()
                .MaximumLength(255);
        }
    }
}
