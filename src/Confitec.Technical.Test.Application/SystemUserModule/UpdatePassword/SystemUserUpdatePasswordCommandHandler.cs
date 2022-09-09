using Confitec.Technical.Test.Domain.SystemUserModule;
using MediatR;

namespace Confitec.Technical.Test.Application.SystemUserModule.UpdatePassword
{
    public class SystemUserUpdatePasswordCommandHandler : IRequestHandler<SystemUserUpdatePasswordCommand, bool>
    {
        private readonly ISystemUserRepository _systemUserRepository;

        public SystemUserUpdatePasswordCommandHandler(ISystemUserRepository systemUserRepository)
        {
            _systemUserRepository = systemUserRepository;
        }

        public async Task<bool> Handle(SystemUserUpdatePasswordCommand request, CancellationToken cancellationToken)
        {
            var systemUser = await _systemUserRepository.GetAsync(SystemUserSpecification.ByUserNameOrMail(request.UserName), true);
            if (systemUser == null) { throw new InvalidDataException("User not found!"); }

            systemUser.UpdatePass(request.Password);

            await _systemUserRepository.UpdateAsync(systemUser);

            return true;
        }
    }
}
