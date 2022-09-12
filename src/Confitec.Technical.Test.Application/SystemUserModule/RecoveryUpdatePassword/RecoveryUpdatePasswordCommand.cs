using FluentValidation;
using MediatR;

namespace Confitec.Technical.Test.Application.SystemUserModule.RecoveryUpdatePassword
{
    public class RecoveryUpdatePasswordCommand : IRequest<bool>
    {
        public string UserName { get; set; }
        public string Code { get; set; }
        public string Password { get; set; }
    }

    public class RecoveryUpdatePasswordValidator : AbstractValidator<RecoveryUpdatePasswordCommand>
    {
        public RecoveryUpdatePasswordValidator()
        {
            RuleFor(p => p.UserName)
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(p => p.Code)
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(p => p.Password)
                .NotEmpty()
                .MaximumLength(255);
        }
    }
}
