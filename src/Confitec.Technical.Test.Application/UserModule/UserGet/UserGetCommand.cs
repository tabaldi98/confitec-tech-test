using FluentValidation;
using MediatR;

namespace Confitec.Technical.Test.Application.UserModule.UserGet
{
    public class UserGetCommand : IRequest<UserGetModel>
    {
        public int ID { get; set; }

        public UserGetCommand()
        { }

        public UserGetCommand(int id)
        {
            ID = id;
        }
    }

    public class UserGetCommandValidator : AbstractValidator<UserGetCommand>
    {
        public UserGetCommandValidator()
        {
            RuleFor(p => p.ID)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
