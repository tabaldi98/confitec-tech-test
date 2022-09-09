using Confitec.Technical.Test.Domain.RecoveryPasswordModule;
using MediatR;

namespace Confitec.Technical.Test.Application.SystemUserModule.RecoveryPasswordValidate
{
    public class SystemUserRecoveryPasswordValidateCommandHandler : IRequestHandler<SystemUserRecoveryPasswordValidateCommand, bool>
    {
        private readonly IRecoveryPasswordRepository _recoveryPasswordRepository;

        public SystemUserRecoveryPasswordValidateCommandHandler(IRecoveryPasswordRepository recoveryPasswordRepository)
        {
            _recoveryPasswordRepository = recoveryPasswordRepository;
        }

        public async Task<bool> Handle(SystemUserRecoveryPasswordValidateCommand request, CancellationToken cancellationToken)
        {
            var recovery = await _recoveryPasswordRepository.RetrieveAsync(RecoveryPasswordSpecification.ByUserName(request.UserName));
            if (recovery == null) { throw new InvalidDataException("Recovery not found!"); }

            var isValid = recovery.ValidateCode(recovery.Code);

            await _recoveryPasswordRepository.UpdateAsync(recovery);

            return isValid;
        }
    }
}
