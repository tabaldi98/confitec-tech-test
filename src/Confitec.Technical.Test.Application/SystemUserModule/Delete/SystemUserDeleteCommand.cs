using FluentValidation;
using MediatR;

namespace Confitec.Technical.Test.Application.SystemUserModule.Delete
{
    public class SystemUserDeleteCommand : IRequest<bool>
    {
        public int[] IDs { get; set; }
    }

    public class SystemUserUpdateCommandValidator : AbstractValidator<SystemUserDeleteCommand>
    {
        public SystemUserUpdateCommandValidator()
        {
            RuleFor(p => p.IDs)
                .NotEmpty();
        }
    }
}
