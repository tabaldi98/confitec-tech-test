using Confitec.Technical.Test.Domain.RecoveryPasswordModule;
using Confitec.Technical.Test.Domain.SystemUserModule;
using Confitec.Technical.Test.Infra.Crosscutting.RabbitMq;
using MediatR;

namespace Confitec.Technical.Test.Application.SystemUserModule.RecoveryPassword
{
    public class SystemUserRecoveryPasswordCommandHandler : IRequestHandler<SystemUserRecoveryPasswordCommand, bool>
    {
        private readonly ISystemUserRepository _systemUserRepository;
        private readonly IRabbitMqConnector _rabbitMqConnector;
        private readonly IRecoveryPasswordRepository _recoveryPasswordRepository;

        public SystemUserRecoveryPasswordCommandHandler(
            ISystemUserRepository systemUserRepository,
            IRabbitMqConnector rabbitMqConnector,
            IRecoveryPasswordRepository recoveryPasswordRepository)
        {
            _systemUserRepository = systemUserRepository;
            _rabbitMqConnector = rabbitMqConnector;
            _recoveryPasswordRepository = recoveryPasswordRepository;
        }

        public async Task<bool> Handle(SystemUserRecoveryPasswordCommand request, CancellationToken cancellationToken)
        {
            var systemUser = await _systemUserRepository.GetAsync(SystemUserSpecification.ByUserNameOrMail(request.UserNameOrLogin), true);
            if (systemUser == null) { throw new InvalidDataException("User not found!"); }

            var recovery = await _recoveryPasswordRepository.RetrieveAsync(RecoveryPasswordSpecification.ByUserName(request.UserNameOrLogin));
            if (recovery == null)
            {
                recovery = new Domain.RecoveryPasswordModule.RecoveryPassword(systemUser);
                await _recoveryPasswordRepository.CreateAsync(recovery);
            }

            _rabbitMqConnector.PublishMessage(new
            {
                ID = systemUser.ID,
                UserName = systemUser.UserName,
                FullName = systemUser.FullName,
                Mail = systemUser.Mail,
                Code = recovery.Code,
            }, RabbitMqConstants.EXCHANGE_MAIL_RECOVERY, RabbitMqConstants.ROUTING_KEY_MAIL_RECOVERY);

            return true;
        }
    }
}
