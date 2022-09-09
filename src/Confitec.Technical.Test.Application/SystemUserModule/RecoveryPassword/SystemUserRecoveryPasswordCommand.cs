using FluentValidation;
using MediatR;

namespace Confitec.Technical.Test.Application.SystemUserModule.RecoveryPassword
{
    public class SystemUserRecoveryPasswordCommand : IRequest<bool>
    {
        public string UserNameOrLogin { get; set; }
    }

    public class SystemUserRecoveryPasswordCommandValidator : AbstractValidator<SystemUserRecoveryPasswordCommand>
    {
        public SystemUserRecoveryPasswordCommandValidator()
        {
            RuleFor(p => p.UserNameOrLogin)
                .NotEmpty()
                .MaximumLength(255);
        }
    }
}
