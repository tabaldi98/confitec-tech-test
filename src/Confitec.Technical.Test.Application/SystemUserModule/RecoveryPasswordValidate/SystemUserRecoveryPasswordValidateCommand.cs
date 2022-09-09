using FluentValidation;
using MediatR;

namespace Confitec.Technical.Test.Application.SystemUserModule.RecoveryPasswordValidate
{
    public class SystemUserRecoveryPasswordValidateCommand : IRequest<bool>
    {
        public string UserName { get; set; }
        public string Code { get; set; }
    }

    public class SystemUserRecoveryPasswordValidateCommandValidator : AbstractValidator<SystemUserRecoveryPasswordValidateCommand>
    {
        public SystemUserRecoveryPasswordValidateCommandValidator()
        {
            RuleFor(p => p.UserName)
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(p => p.Code)
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}
