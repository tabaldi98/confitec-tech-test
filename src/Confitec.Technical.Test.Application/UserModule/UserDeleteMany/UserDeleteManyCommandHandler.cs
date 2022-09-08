using Confitec.Technical.Test.Domain.UserModule;
using MediatR;

namespace Confitec.Technical.Test.Application.UserModule.UserDeleteMany
{
    internal class UserDeleteManyCommandHandler : IRequestHandler<UserDeleteManyCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public UserDeleteManyCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(UserDeleteManyCommand request, CancellationToken cancellationToken)
        {
            return await _userRepository.DeleteManyAsync(request.IDs);
        }
    }
}
