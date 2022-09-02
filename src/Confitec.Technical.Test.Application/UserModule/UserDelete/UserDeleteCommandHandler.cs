using Confitec.Technical.Test.Domain.UserModule;
using MediatR;

namespace Confitec.Technical.Test.Application.UserModule.UserDelete
{
    public class UserDeleteCommandHandler : IRequestHandler<UserDeleteCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public UserDeleteCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(UserDeleteCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(UserSpecification.ById(request.ID), true);
            if (user == null) { throw new InvalidDataException("User not found"); }

            return await _userRepository.DeleteAsync(user);
        }
    }
}
