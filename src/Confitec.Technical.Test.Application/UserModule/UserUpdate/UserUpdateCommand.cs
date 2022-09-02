using Confitec.Technical.Test.Domain.UserModule;
using FluentValidation;
using MediatR;

namespace Confitec.Technical.Test.Application.UserModule.UserUpdate
{
    public class UserUpdateCommand : IRequest<bool>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public DateTime BirthDate { get; set; }
        public UserScholarity Scholarity { get; set; }
    }

    public class UserUpdateCommandValidator : AbstractValidator<UserUpdateCommand>
    {
        public UserUpdateCommandValidator()
        {
            RuleFor(p => p.ID)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(p => p.Name)
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(p => p.Surname)
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(p => p.Mail)
                .NotEmpty()
                .MaximumLength(255)
                .EmailAddress();

            RuleFor(p => p.BirthDate)
                .GreaterThan(DateTime.MinValue)
                .LessThanOrEqualTo(DateTime.Now);

            RuleFor(p => p.Scholarity)
                .NotNull()
                .IsInEnum();
        }
    }
}
