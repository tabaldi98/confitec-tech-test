using Confitec.Technical.Test.Domain.SystemUserModule.Permissions;
using FluentValidation;
using MediatR;

namespace Confitec.Technical.Test.Application.SystemUserModule.Update
{
    public class SystemUserUpdateCommand : IRequest<bool>
    {
        public int ID { get; set; }
        public bool IsAproved { get; set; }
        public IList<string> Permissions { get; set; }
    }

    public class SystemUserUpdateCommandValidator : AbstractValidator<SystemUserUpdateCommand>
    {
        public SystemUserUpdateCommandValidator()
        {
            RuleFor(p => p.ID)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(p => p.Permissions)
                .NotNull();
        }
    }
}
