using FluentValidation;
using MediatR;

namespace Confitec.Technical.Test.Application.SystemUserModule.UpdatePassword
{
    public class UpdatePasswordCommand : IRequest<bool>
    {
        public int UserId { get; set; }
        public string CurrentPassword { get; set; }
        public string Password { get; set; }
    }

    public class UpdatePasswordValidator : AbstractValidator<UpdatePasswordCommand>
    {
        public UpdatePasswordValidator()
        {
            RuleFor(p => p.CurrentPassword)
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(p => p.Password)
                .NotEmpty()
                .MaximumLength(255);
        }
    }
}
