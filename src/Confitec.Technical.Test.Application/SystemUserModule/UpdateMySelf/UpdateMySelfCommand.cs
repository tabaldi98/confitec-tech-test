using FluentValidation;
using MediatR;

namespace Confitec.Technical.Test.Application.SystemUserModule.UpdateMySelf
{
    public class UpdateMySelfCommand : IRequest<bool>
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Mail { get; set; }
    }

    public class UpdateMySelfCommandValidator : AbstractValidator<UpdateMySelfCommand>
    {
        public UpdateMySelfCommandValidator()
        {
            RuleFor(p => p.FullName)
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(p => p.Mail)
                .NotEmpty()
                .MaximumLength(255)
                .EmailAddress();
        }
    }
}
