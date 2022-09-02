using FluentValidation;
using MediatR;

namespace Confitec.Technical.Test.Application.UserModule.UserDelete
{
    public class UserDeleteCommand : IRequest<bool>
    {
        public int ID { get; set; }

        public UserDeleteCommand(int id)
        {
            ID = id;
        }
    }

    public class UserDeleteCommandValidator : AbstractValidator<UserDeleteCommand>
    {
        public UserDeleteCommandValidator()
        {
            RuleFor(p => p.ID)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
