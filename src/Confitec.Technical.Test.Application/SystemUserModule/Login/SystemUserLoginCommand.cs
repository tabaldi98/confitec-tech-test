using FluentValidation;
using MediatR;

namespace Confitec.Technical.Test.Application.SystemUserModule.Login
{
    public class SystemUserLoginCommand : IRequest<SystemUserLoginModel>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }

    public class SystemUserLoginCommandValidator : AbstractValidator<SystemUserLoginCommand>
    {
        public SystemUserLoginCommandValidator()
        {
            RuleFor(p => p.Login)
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(p => p.Password)
                .NotEmpty()
                .MaximumLength(255);
        }
    }
}
