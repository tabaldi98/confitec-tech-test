using Confitec.Technical.Test.Domain.RecoveryPasswordModule;
using Confitec.Technical.Test.Domain.SystemUserModule;
using MediatR;

namespace Confitec.Technical.Test.Application.SystemUserModule.RecoveryUpdatePassword
{
    public class RecoveryUpdatePasswordCommandHandler : IRequestHandler<RecoveryUpdatePasswordCommand, bool>
    {
        private readonly ISystemUserRepository _systemUserRepository;
        private readonly IRecoveryPasswordRepository _recoveryPasswordRepository;

        public RecoveryUpdatePasswordCommandHandler(
            ISystemUserRepository systemUserRepository,
            IRecoveryPasswordRepository recoveryPasswordRepository)
        {
            _systemUserRepository = systemUserRepository;
            _recoveryPasswordRepository = recoveryPasswordRepository;
        }

        public async Task<bool> Handle(RecoveryUpdatePasswordCommand request, CancellationToken cancellationToken)
        {
            var systemUser = await _systemUserRepository.GetAsync(SystemUserSpecification.ByUserNameOrMail(request.UserName), true);
            if (systemUser == null) { throw new InvalidDataException("User not found!"); }

            var recovery = await _recoveryPasswordRepository.RetrieveAsync(RecoveryPasswordSpecification.ByUserName(request.UserName));
            if (recovery == null) { throw new InvalidDataException("Recovery not found!"); }

            if (!recovery.ValidateCode(request.Code))
            {
                throw new InvalidOperationException("Invalid code!");
            }

            systemUser.UpdatePass(request.Password);
            await _systemUserRepository.UpdateAsync(systemUser);

            recovery.SetAsUsed();
            await _recoveryPasswordRepository.UpdateAsync(recovery);

            return true;
        }
    }
}
