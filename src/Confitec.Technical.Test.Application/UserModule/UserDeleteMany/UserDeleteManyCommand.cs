using FluentValidation;
using MediatR;

namespace Confitec.Technical.Test.Application.UserModule.UserDeleteMany
{
    public class UserDeleteManyCommand : IRequest<bool>
    {
        public int[] IDs { get; set; }
    }

    public class UserDeleteManyCommandValidator: AbstractValidator<UserDeleteManyCommand>
    {
        public UserDeleteManyCommandValidator()
        {
            RuleForEach(p => p.IDs)
                .GreaterThan(0);
        }
    }
}
