using FluentValidation;
using MediatR;

namespace Confitec.Technical.Test.Application.SystemUserModule.UpdatePassword
{
    public class SystemUserUpdatePasswordCommand : IRequest<bool>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class SystemUserUpdatePasswordCommandValidator : AbstractValidator<SystemUserUpdatePasswordCommand>
    {
        public SystemUserUpdatePasswordCommandValidator()
        {
            RuleFor(p => p.UserName)
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(p => p.Password)
                .NotEmpty()
                .MaximumLength(255);
        }
    }
}
