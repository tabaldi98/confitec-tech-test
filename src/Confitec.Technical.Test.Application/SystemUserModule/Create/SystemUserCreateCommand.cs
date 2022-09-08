using FluentValidation;
using MediatR;

namespace Confitec.Technical.Test.Application.SystemUserModule.Create
{
    public class SystemUserCreateCommand : IRequest<int>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
    }

    public class SystemUserCreateCommandValidator : AbstractValidator<SystemUserCreateCommand>
    {
        public SystemUserCreateCommandValidator()
        {
            RuleFor(p => p.UserName)
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(p => p.Password)
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(p => p.Mail)
                .NotEmpty()
                .MaximumLength(255)
                .EmailAddress();
        }
    }

}
