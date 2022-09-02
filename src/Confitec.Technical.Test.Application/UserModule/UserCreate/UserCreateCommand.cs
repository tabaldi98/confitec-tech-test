using Confitec.Technical.Test.Domain.UserModule;
using FluentValidation;
using MediatR;

namespace Confitec.Technical.Test.Application.UserModule.UserCreate
{
    public class UserCreateCommand : IRequest<int>
    {
        public string Name { get;  set; }
        public string Surname { get;  set; }
        public string Mail { get;  set; }
        public DateTime BirthDate { get;  set; }
        public UserScholarity Scholarity { get;  set; }
    }

    public class UserCreateCommandValidator : AbstractValidator<UserCreateCommand>
    {
        public UserCreateCommandValidator()
        {
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
